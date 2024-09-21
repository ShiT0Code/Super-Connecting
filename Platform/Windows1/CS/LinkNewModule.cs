using DevicesInterconnection.ViewModuls.LinkNew;
using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevicesInterconnection.CS
{
    public class LinkNewModule
    {
        public static async Task StartLinking(string ip, string PIN)
        {
            //Some Data is only for Test.
            string DevicesType = "Desktop PC";
            string Brand = "Micosoft";
            DateTime SendTime = DateTime.Now;


            string RecePIN = "";
            string[] KeyWords = [];

            bool IsFinish;
            do
            {
                IsFinish = false;
                string result = await NetworkModule.StartInNetSend(ip, $"A,{PIN},{SendTime}," +
                    $"{Environment.MachineName},{DevicesType},{Brand},{RuntimeInformation.OSDescription}");

                if (result.StartsWith("Error"))
                {
                    var not = new AppNotificationBuilder()
                        .AddText("发生了错误！")
                        .AddText("错误详情：")
                        .AddText(result);
                    AppNotificationManager.Default.Show(not.BuildNotification());
                    IsFinish = true;
                }
                else
                {
                    KeyWords = result.Split(',');

                    RecePIN = KeyWords[1];
                    IsFinish = true;
                }
            }
            while (RecePIN != PIN && IsFinish);

            string ReceName = KeyWords[3];
            string IsAccept = KeyWords[0];

            DateTime ReceTime;
            DateTime.TryParse(KeyWords[2], out ReceTime);

            if (IsAccept == "A")
            {
                if (ReceTime < SendTime.AddMinutes(15))
                {
                    var not2 = new AppNotificationBuilder()
                        .AddText("1")
                        .AddText($"在与设备{ReceName}配对时OK！");
                    AppNotificationManager.Default.Show(not2.BuildNotification());
                }
                else
                {
                    var not1 = new AppNotificationBuilder()
                        .AddText("配对超时！")
                        .AddText($"在与设备{ReceName}配对时用时超时，请再试一次！");
                    AppNotificationManager.Default.Show(not1.BuildNotification());
                }
            }
        }



        public static List<List<string>> CollectInfos = new();

        public static async Task CollectingDevices()
        {

            while (true)
            {
                string CollectedInfo = await NetworkModule.InNetReceiveReplies(12568);

                if (CollectedInfo.StartsWith("Error"))
                {
                    continue;
                }

                string[] KeyWords = CollectedInfo.Split(',');

                string type = KeyWords[0];

                if (type == "C")
                {
                    continue;
                }

                List<string> Infos = new()
                {
                    KeyWords[3],
                    KeyWords[1],
                    KeyWords[4],
                    KeyWords[5],
                    KeyWords[2],
                    KeyWords[6]
                };

                CollectInfos.Add(Infos);

                var butt1 = new AppNotificationButton("确定")
                    .AddArgument("action", "OK");
                var butt2 = new AppNotificationButton("查看")
                    .AddArgument("action", "View");

                var not = new AppNotificationBuilder()
                    .AddText("有新的设备要添加")
                    .AddText($"设备 {KeyWords[3]} 想要被你添加")
                    .AddButton(butt1)
                    .AddButton(butt2);
                AppNotificationManager.Default.Show(not.BuildNotification());

                await Task.Delay(10000);
            }
        }

        public static async Task AcceptToAdd(string PINCode,string DevicesName)
        {
            string ThisDevicesType = "PC";
            string ThisBrand = "Microsoft";

            string message = $"A,{PINCode},{DateTime.Now}," +
                    $"{Environment.MachineName},{ThisDevicesType},{ThisBrand},{RuntimeInformation.OSDescription}";

            
            foreach (List<string> list in CollectInfos)
            {
                if (list[0] == DevicesName)
                {
                    CollectInfos.Remove(list);

                    break;
                }
            }
            await NetworkModule.StartInNetSend("", message);
        }
    }
}
