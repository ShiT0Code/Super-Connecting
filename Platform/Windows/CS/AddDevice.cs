using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperConnecting_Windows.CS;

public class AddDevice
{
    public static async Task<string> SendPIN(string PINCode)
    {
        NetworkModule network = new();

        var not = new AppNotificationBuilder()
            .AddText("发送配对码")
            .AddText($"我们已经向你所在的网络发送了添加请求，配对码为 {PINCode}");

        AppNotificationManager.Default.Show(not.BuildNotification());

        string result = await network.ProcessingRequests(0, true, "");

        return "";
    }
}
