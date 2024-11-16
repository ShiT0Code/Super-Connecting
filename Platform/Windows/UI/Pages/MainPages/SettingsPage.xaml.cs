using Microsoft.UI.Xaml.Controls;
using SuperConnecting_Windows.UI.Pages.SecondaryPage.Settings;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SuperConnecting_Windows.UI.Pages.MainPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void SelectorBar_SelectionChanged(SelectorBar sender, SelectorBarSelectionChangedEventArgs args)
        {
            SelectorBarItem selectorBarItem = sender.SelectedItem;
            int currentSelectedIndex = sender.Items.IndexOf(selectorBarItem);

            switch (currentSelectedIndex)
            {
                case 0:
                    SettingFrame.Navigate(typeof(General));
                    break;
                case 1:
                    SettingFrame.Navigate(typeof(Network));
                    break;
                case 2:
                    SettingFrame.Navigate(typeof(UsersManage));
                    break;
                case 3:
                    SettingFrame.Navigate(typeof(Assistive));
                    break;
                case 4:
                    SettingFrame.Navigate(typeof(About));
                    break;
                default:
                    SettingFrame.Navigate(typeof(General));
                    break;
            }
        }
    }
}
