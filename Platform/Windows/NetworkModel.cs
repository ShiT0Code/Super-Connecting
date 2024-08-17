using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Windows.AppNotifications.Builder;
using Microsoft.Windows.AppNotifications;

namespace DevicesInterconnection
{
    public class NetworkModel
    {
        public static async Task<bool> StartInNetSend(string targetAddress, string Port, string message)
        {
            int targetPort;
            //检查端口号
            if (!int.TryParse(Port, out targetPort))
            {
                
                //产生新的端口号
                Random random = new();
                targetPort = random.Next(0, 9999 + 1);
                //Console.WriteLine(targetPort);
            }
            message = $"{targetPort},{message}";
            message = EncryptionModule.EncryptString(message);
            //结果
            string result = "";

            if (targetAddress != "" && targetAddress != null)
            //定义了ip
            {
                //Console.WriteLine("定义了ip");
                result = await InNetSendMessage(targetAddress, targetPort, message);
            }
            else
            {
                //向所有发送
                //Console.WriteLine("向所有发送");
                result = await InNetSendtoAll(message, targetPort);
            }

            if (result.StartsWith("Error:"))
            {

                return false;
            }

            result = await InNetReceiveReplies(targetPort);

            if (result.StartsWith("Error:"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static async Task<string> InNetSendMessage(string targetAddress, int targetPort, string message)
        {
            // 将设备名称解析为IP地址
            string ipAddress = await InNetResolveToIPAddress(targetAddress);

            if (ipAddress == null)
            {
                //Console.WriteLine("无法解析目标地址。");
                return "Error:Can not get IP.";
            }

            using (UdpClient udpClient = new UdpClient())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), targetPort);

                try
                {
                    await udpClient.SendAsync(bytes, bytes.Length, endPoint);
                    var a = new AppNotificationBuilder()
                        .AddText(message);
                    AppNotificationManager.Default.Show(a.BuildNotification());
                    return $"Succ";
                }
                catch (Exception ex)
                {
                    return $"Error:{ex.Message}";
                }
            }
        }

        static async Task<string> InNetSendtoAll(string message, int port)
        {
            UdpClient udpClient = new UdpClient();
            string ret = "";
            try
            {
                udpClient.EnableBroadcast = true;

                byte[] bytes = Encoding.UTF8.GetBytes(message);
                await udpClient.SendAsync(bytes, bytes.Length, new IPEndPoint(IPAddress.Broadcast, port));
                var a = new AppNotificationBuilder()
                        .AddText(message);
                AppNotificationManager.Default.Show(a.BuildNotification());
                ret = "Succ";
            }
            catch (Exception ex)
            {
                ret = $"Error:{ex}";
            }
            finally
            {
                udpClient.Close();
            }
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
                //Console.WriteLine($"解析地址时发生异常: {ex.Message}");
                var a = new AppNotificationBuilder()
                        .AddText($"解析地址时发生异常: {ex.Message}");
                AppNotificationManager.Default.Show(a.BuildNotification());
                return $"Error:{ex.Message}";
            }
        }

        static async Task<string> InNetReceiveReplies(int port)
        {
            string ret = "";
            using (UdpClient udpClient = new UdpClient(port))
            {
                udpClient.Client.ReceiveTimeout = 10000; // 设置接收超时时间为10秒（10000毫秒）
                Console.WriteLine($"在端口 {port} 上等待回复...");

                try
                {
                    UdpReceiveResult result = await udpClient.ReceiveAsync();
                    string receivedMessage = Encoding.UTF8.GetString(result.Buffer);
                    receivedMessage = EncryptionModule.DecryptString(receivedMessage);
                    ret = receivedMessage;
                    var c = new AppNotificationBuilder()
                        .AddText(receivedMessage);
                    AppNotificationManager.Default.Show(c.BuildNotification());
                }
                catch (SocketException ex) when (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    ret = $"Error:TimeOut:{ex}";
                }
                catch (Exception ex)
                {
                    ret = $"Error:{ex.Message}";
                }
                finally
                {
                    udpClient.Close();
                }
            }
            Console.WriteLine(ret);
            var b = new AppNotificationBuilder()
                .AddText(ret);
            AppNotificationManager.Default.Show(b.BuildNotification());
            return ret;
        }

    }
}
