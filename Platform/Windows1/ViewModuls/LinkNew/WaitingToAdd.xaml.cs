using DevicesInterconnection.CS;
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
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevicesInterconnection.ViewModuls.LinkNew
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WaitingToAdd : Page
    {
        public WaitingToAdd()
        {
            this.InitializeComponent();
            LinkNewViewModel1 = new WaitingLinkingNewViewModel();
        }
        public WaitingLinkingNewViewModel LinkNewViewModel1 { get; set; }



        private void ItemsView_ItemInvoked(ItemsView sender, ItemsViewItemInvokedEventArgs e)
        {
            DeName.Text = (e.InvokedItem as WaitingLinkingNewData).Name;
            DeType.Text = (e.InvokedItem as WaitingLinkingNewData).DeviceType;
            PINcode.Text = (e.InvokedItem as WaitingLinkingNewData).PIN;
            SendT.Text = (e.InvokedItem as WaitingLinkingNewData).SendTime;
            DeOS.Text = (e.InvokedItem as WaitingLinkingNewData).OS;
            DeBrand.Text = (e.InvokedItem as WaitingLinkingNewData).Brand;
        }

        private async void Accect_Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new()
            {
                XamlRoot = this.XamlRoot,
                Title = "确认配对？",
                Content = $"你正在与设备 {DeName.Text} 进行配对，确认配对吗？",
                PrimaryButtonText = "确认配对",
                CloseButtonText = "取消",
                DefaultButton = ContentDialogButton.Primary
            };

            ContentDialogResult result = await dialog.ShowAsync();

            string DevicesName = DeName.Text;

            Sent.Message = $"已向设备 {DevicesName} 发送通知";
            Sent.IsOpen = true;

            if(result==ContentDialogResult.Primary)
            {
                string Pin = PINcode.Text;

                Task.Run(async () =>
                {
                    await LinkNewModule.AcceptToAdd(Pin, DevicesName);
                });
            }
            else
            {
                ;
            }
        }
    }
}
