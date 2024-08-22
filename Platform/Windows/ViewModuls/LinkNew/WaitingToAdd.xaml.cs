using DevicesInterconnection.CS;
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
            ViewModelWLN = new WaitingLinkingNewViewModel();
        }
        public WaitingLinkingNewViewModel ViewModelWLN { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModelWLN.WLNViewModel.Add(new WaitingLinkingNewData
            {
                Name = "A",
                PIN = "jio",
                DeviceType = "Phone",
                Brand = "Microsoft",
                SendTime = "2024/8/32 25:00:00",
                OS = "Microsoft Windows 12 Pro"
            });
        }
    }
}