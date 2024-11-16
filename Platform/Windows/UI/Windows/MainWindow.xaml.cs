using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SuperConnecting_Windows.UI.Pages.MainPages;
using System;
using System.Collections.Generic;

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
                HeaderText.Text = "…Ë÷√";
                mainFram.Navigate(typeof(SettingsPage));

                HistoryNavHeader.Add("…Ë÷√");
                HistoryNavIndex.Add(3);
            }
            else
            {
                var selectedItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
                string selectedItemTag = ((string)selectedItem.Tag);

                string title = ((string)selectedItem.Content);

                HistoryNavHeader.Add(title);
                HistoryNavIndex.Add(sender.MenuItems.IndexOf(selectedItem));

                HeaderText.Text = title;

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

                HeaderText.Text = HistoryNavHeader[HistoryNavHeader.Count - 1];

                Nav.SelectionChanged -= Nav_SelectionChanged;
                int a = HistoryNavIndex[HistoryNavIndex.Count - 1];
                if (a == 3)
                    Nav.SelectedItem = Nav.SettingsItem;
                else
                    Nav.SelectedItem = Nav.MenuItems[a];
                Nav.SelectionChanged += Nav_SelectionChanged;
            }
        }

        private void mainFram_Navigating(object sender, Microsoft.UI.Xaml.Navigation.NavigatingCancelEventArgs e)
        {
            Loading.Width = 999999;
            Loading.IsIndeterminate = true;
        }

        private void mainFram_Navigated(object sender, Microsoft.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            Loading.Width = 0;
            Loading.IsIndeterminate = false;
        }
    }
}
