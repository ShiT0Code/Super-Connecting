using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Windows.AppNotifications.Builder;
using Microsoft.Windows.AppNotifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevicesInterconnection.ModelPages.AddNew
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BySend : Page
    {
        public BySend()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ToSw1_Toggled(object sender, RoutedEventArgs e)
        {
            if (ToSw1.IsOn)
            {
                Chk1.IsEnabled = Chk2.IsEnabled = true;
                Chk1.IsChecked = Chk2.IsChecked = true;
            }
            else
            {
                Chk1.IsEnabled = Chk2.IsEnabled = false;
                Chk1.IsChecked = Chk2.IsChecked = false;
            }
        }

        private void Chk1_Checked(object sender, RoutedEventArgs e)
        {
            if(Chk1.IsChecked==true)
            {
                ip1.IsEnabled = true;
            }
            else
            {
                ip1.IsEnabled = false;
            }
        }

        private void Chk2_Checked(object sender, RoutedEventArgs e)
        {
            if (Chk2.IsChecked == true)
            {
                port1.IsEnabled = true;
            }
            else
            {
                port1.IsEnabled = false;
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool succ = await NetworkModel.StartInNetSend("192.168.1.5", "25565", "Abc");
            var a = new AppNotificationBuilder()
        .AddText(succ.ToString());
            AppNotificationManager.Default.Show(a.BuildNotification());
        }
    }
}
