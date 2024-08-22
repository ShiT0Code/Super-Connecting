using DevicesInterconnection.ViewModuls.MainPages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevicesInterconnection.ViewModuls
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            SetTitleBar(titleBar);
        }

        private void Nav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if(args.IsSettingsSelected)
            {
                sender.Header = "设置";

            }
            else
            {
                var Item = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
                string Tag = ((string)Item.Tag);
                switch(Tag)
                {
                    case "Home":
                        sender.Header = "主页";
                        frame.Navigate(typeof(Home));
                        break;
                    case "MyDe":
                        sender.Header = "我的设备";
                        break;
                    case "LinkNew":
                        sender.Header = "添加新的设备";
                        frame.Navigate(typeof(LinkNewMain));
                        break;
                }
            }
        }

        private void frame_Loaded(object sender, RoutedEventArgs e)
        {
            Nav.SelectedItem = Nav.MenuItems[0];
            Nav.TabIndex = 0;
        }
    }
}
