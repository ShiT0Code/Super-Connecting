using DevicesInterconnection.ModelPages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevicesInterconnection
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            SetTitleBar(TitltBar);
        }




        private void Nav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                PageHeader.Text = "设置";
                //frame.Navigate(typeof(SampleSettingsPage));
            }
            var Item = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
            string Tag= ((string)Item.Tag);
            switch (Tag)
            {
                case "Home":
                    PageHeader.Text = "主页";
                    frame.Navigate(typeof(Home));
                    break;
                case "MyDevices":
                    PageHeader.Text = "我的设备";
                    frame.Navigate(typeof(MyDevices));
                    break;
                case "AddNew":
                    PageHeader.Text = "添加设备";
                    frame.Navigate(typeof(AddNewMenu));
                    break;
                case "WaitingToAdd":
                    PageHeader.Text = "待添加的设备";
                    frame.Navigate(typeof(WaitingToAdd));
                    break;
                case "LinkToNew":
                    PageHeader.Text = "添加新设备";
                    frame.Navigate(typeof(AddaNew));
                    break;
            }
        }

        private void Nav_PaneOpening(NavigationView sender, object args)
        {
            SpltV.IsPaneOpen = true;
        }

        private void Nav_PaneClosing(NavigationView sender, NavigationViewPaneClosingEventArgs args)
        {
            SpltV.IsPaneOpen = false;
        }

        private void frame_Loaded(object sender, RoutedEventArgs e)
        {
            Nav.SelectedItem = Nav.MenuItems[0];
            Nav.TabIndex = 0;
        }
    }
}
