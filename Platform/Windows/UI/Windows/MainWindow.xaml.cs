using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SuperConnecting_Windows.UI.Pages.MainPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SuperConnecting_Windows.UI.Windows
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            ExtendsContentIntoTitleBar = true;
            SetTitleBar(TitBar);
        }

        public static List<int> HistoryNavIndex = new();
        public static List<string> HistoryNavHeader = new();

        private void Nav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (sender.SelectedItem == sender.SettingsItem)
            {
                sender.Header = "����";
                mainFram.Navigate(typeof(SettingsPage));

                HistoryNavHeader.Add("����");
                HistoryNavIndex.Add(3);
            }
            else
            {
                var selectedItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
                string selectedItemTag = ((string)selectedItem.Tag);

                string title = ((string)selectedItem.Content);

                HistoryNavHeader.Add(title);
                HistoryNavIndex.Add(sender.MenuItems.IndexOf(selectedItem));

                sender.Header = title;

                string pageName = "SuperConnecting_Windows.UI.Pages.MainPages." + selectedItemTag + "Page";
                Type pageType = Type.GetType(pageName);

                mainFram.Navigate(pageType);
            }
        }

        private void Nav_Loaded(object sender, RoutedEventArgs e)
        {
            Nav.SelectedItem = Nav.MenuItems[0];
        }
        
        private void Nav_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (mainFram.CanGoBack)
            {
                mainFram.GoBack();

                HistoryNavHeader.RemoveAt(HistoryNavHeader.Count - 1);
                HistoryNavIndex.RemoveAt(HistoryNavIndex.Count - 1);

                Nav.Header = HistoryNavHeader[HistoryNavHeader.Count - 1];

                Nav.SelectionChanged -= Nav_SelectionChanged;
                int a = HistoryNavIndex[HistoryNavIndex.Count - 1];
                if (a == 3)
                    Nav.SelectedItem = Nav.SettingsItem;
                else
                    Nav.SelectedItem = Nav.MenuItems[a];
                Nav.SelectionChanged += Nav_SelectionChanged;
            }
        }
    }
}
