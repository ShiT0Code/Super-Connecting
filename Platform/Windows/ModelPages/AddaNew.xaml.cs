using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using DevicesInterconnection.ModelPages.AddNew;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevicesInterconnection.ModelPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddaNew : Page
    {
        public AddaNew()
        {
            this.InitializeComponent();
        }

        private void Nav2_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var Item1 = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
            string Tag1 = ((string)Item1.Tag);
            switch(Tag1)
            {
                case "A":
                    break;
                case "B":
                    fr1.Navigate(typeof(BySend));
                    break;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Nav2.SelectedItem = Nav2.MenuItems[0];
            Nav2.TabIndex = 0;
        }
    }
}
