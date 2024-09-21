using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SuperConnecting_Windows.UI.MainPages;
using SuperConnecting_Windows.UI.ScondaryPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SuperConnecting_Windows.UI.WindowUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.SystemBackdrop = new MicaBackdrop { Kind = MicaKind.Base };

            this.Title = "主窗口";
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(TitleBarGrid);

            if (ExtendsContentIntoTitleBar == true)
            {
                this.AppWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Tall;
            }
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                    sender.Header = "设置";
                    //frame.Navigate(typeof(InviteDevicePage));
            }
            else
            {
                var selItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
                string selTag = (string)selItem.Tag;

                switch(selTag)
                {
                    case "Home":
                        sender.Header = "主页";
                        frame.Navigate(typeof(HomePage));
                        break;

                    case "MyInfo":
                        sender.Header = "我的";
                        frame.Navigate(typeof(MyInfosPage));
                        break;

                    case "MyDevices":
                        sender.Header = "我的设备";
                        frame.Navigate(typeof(MyDevicesPage));
                        break;

                    case "AddDevice":
                        sender.Header = "添加设备";
                        frame.Navigate(typeof(AddDevicesPage));
                        break;
                    case "InviteDevice":
                        sender.Header = "添加其他设备";
                        frame.Navigate(typeof(InviteDevicePage));
                        break;

                    case "AddingList":
                        sender.Header = "添加列表";
                        frame.Navigate(typeof(AddingListPage));
                        break;
                }
            }
        }

        private void Nav_Loaded(object sender, RoutedEventArgs e)
        {
            Nav.SelectedItem = Nav.MenuItems[0];
        }
    }
}
