using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SuperConnecting_Windows.CS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SuperConnecting_Windows.UI.Pages.MainPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddDevicePage : Page
    {
        public AddDevicePage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            sendBu.IsEnabled = false;

            finished.Width = 0;
            sending.IsActive = true;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var stringBuilder = new StringBuilder(8);

            for (int i = 0; i < 8; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }

            string pin = stringBuilder.ToString();

            await AddDevice.SendPIN(pin);

            Message.Severity = InfoBarSeverity.Success;
            Message.Message = $"已发送，配对码为 {pin}";
            Message.IsOpen = true;

            finished.Width = 30;
            sending.IsActive = false;
            sendBu.IsEnabled = true;
        }
    }
}
