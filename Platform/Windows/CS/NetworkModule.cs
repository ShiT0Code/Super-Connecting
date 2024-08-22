using Microsoft.Windows.AppNotifications.Builder;
using Microsoft.Windows.AppNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DevicesInterconnection.CS
{
    public class NetworkModule
    {
        public static async Task<string> StartInNetSend(string targetAddress, string message)
        {
            int targetPort = 12568;

            message = EncryptionModule.EncryptString(message);
            
            string result = "";

            if (targetAddress != "" && targetAddress != null)
            {
                result = await InNetSendMessage(targetAddress, targetPort, message);
            }
            else
            {
                result = await InNetSendtoAll(message, targetPort);
            }

            if (result.StartsWith("Error:"))
            {
                return result;
            }

            result = await InNetReceiveReplies(targetPort);

            if (result.StartsWith("Error:"))
            {
                return result;
            }
            return result;
        }

        static async Task<string> InNetSendMessage(string targetAddress, int targetPort, string message)
        {
            string ipAddress = await InNetResolveToIPAddress(targetAddress);

            if (ipAddress == null)
            {
                var builder = new AppNotificationBuilder()
                    .AddText("发送失败")
                    .AddText("无法解析目标地址：" + targetAddress
                    + "，目标设备可能不存在");
                return "Error:Can not get IP.";
            }

            using (UdpClient udpClient = new UdpClient())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), targetPort);
                string ret = "";
                for (int i=3;i>=0;i--)
                {
                    try
                    {
                        await udpClient.SendAsync(bytes, bytes.Length, endPoint);

                        return $"Succ";
                    }
                    catch (Exception ex)
                    {
                        var Output = new AppNotificationBuilder()
                            .AddText("发送失败")
                            .AddText($"剩余尝试次数：{i}")
                            .AddText("失败原因：")
                            .AddText(ex.Message);
                        AppNotificationManager.Default.Show(Output.BuildNotification());
                        ret = $"Error:{ex.Message}";
                    }
                }
                return ret;
            }
        }

        static async Task<string> InNetSendtoAll(string message, int port)
        {
            UdpClient udpClient = new UdpClient();
            string ret = "";
            for(int i=3;i>=0;i--)
            {
                try
                {
                    udpClient.EnableBroadcast = true;

                    byte[] bytes = Encoding.UTF8.GetBytes(message);
                    await udpClient.SendAsync(bytes, bytes.Length, new IPEndPoint(IPAddress.Broadcast, port));

                    ret = "Succ";
                }
                catch (Exception ex)
                {
                    ret = $"Error:{ex}";
                    var Output = new AppNotificationBuilder()
                            .AddText("发送失败")
                            .AddText($"剩余尝试次数：{i}")
                            .AddText("失败原因：")
                            .AddText(ex.Message);
                    AppNotificationManager.Default.Show(Output.BuildNotification());
                }
            }
            udpClient.Close();
            return ret;
        }

        static async Task<string> InNetResolveToIPAddress(string address)
        {
            try
            {
                IPHostEntry hostEntry = await Dns.GetHostEntryAsync(address);
                return hostEntry.AddressList[0].ToString();
            }
            catch (Exception ex)
            {
                var a = new AppNotificationBuilder()
                        .AddText($"解析地址时发生异常: {ex.Message}");
                AppNotificationManager.Default.Show(a.BuildNotification());
                return $"Error:{ex.Message}";
            }
        }

        public static async Task<string> InNetReceiveReplies(int port)
        {
            string ret = "";
            using (UdpClient udpClient = new UdpClient(port))
            {
                udpClient.Client.ReceiveTimeout = 900000;

                try
                {
                    UdpReceiveResult result = await udpClient.ReceiveAsync();
                    string receivedMessage = Encoding.UTF8.GetString(result.Buffer);
                    receivedMessage = EncryptionModule.DecryptString(receivedMessage);
                    ret = receivedMessage;
                }
                catch (SocketException ex) when (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    ret = $"Error:TimeOut:{ex}";
                    var timeOutput = new AppNotificationBuilder()
                        .AddText("配对失败")
                        .AddText("没有在规定时间内完成配对任务");
                    AppNotificationManager.Default.Show(timeOutput.BuildNotification());
                }
                catch (Exception ex)
                {
                    ret = $"Error:{ex.Message}";
                    var Output = new AppNotificationBuilder()
                        .AddText("发送失败")
                        .AddText("失败原因：")
                        .AddText(ex.Message);
                    AppNotificationManager.Default.Show(Output.BuildNotification());
                }
                finally
                {
                    udpClient.Close();
                }
            }
            return ret;
        }
    }
}
