using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SuperConnecting_Windows.UI.Pages.SecondaryPage.AddDevice;
using SuperConnecting_Windows.UI.Windows;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddByPIN));

            MainWindow.HistoryNavHeader.Add("ÃÌº”…Ë±∏");
            MainWindow.HistoryNavIndex.Add(1);
        }
    }
}
