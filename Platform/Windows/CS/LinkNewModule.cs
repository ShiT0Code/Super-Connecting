using DevicesInterconnection.ViewModuls.LinkNew;
using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevicesInterconnection.CS
{
    public class LinkNewModule
    {
        public static async Task StartLinking(string ip,string PIN)
        {
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
    }
}
