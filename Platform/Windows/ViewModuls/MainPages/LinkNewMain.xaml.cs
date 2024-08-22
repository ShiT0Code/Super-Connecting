using DevicesInterconnection.ViewModuls.LinkNew;
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

namespace DevicesInterconnection.ViewModuls.MainPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LinkNewMain : Page
    {
        public LinkNewMain()
        {
            this.InitializeComponent();
        }

        private void SelectorBar_SelectionChanged(SelectorBar sender, SelectorBarSelectionChangedEventArgs args)
        {
            var selItem = sender.SelectedItem;
            int selIndex = sender.Items.IndexOf(selItem);

            switch (selIndex)
            {
                case 0:
                    break;
                case 1:
                    frame1.Navigate(typeof(BySend));
                    break;
                case 2:
                    frame1.Navigate(typeof(WaitingToAdd));
                    break;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SelBar.TabIndex = 0;
        }
    }
}
