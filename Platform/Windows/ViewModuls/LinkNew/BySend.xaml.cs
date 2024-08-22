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
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DevicesInterconnection.ViewModuls.LinkNew
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BySend : Page
    {
        public BySend()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string SetIP = "";
            string PIN = "";

            if (ched_IP.IsChecked == true)
            {
                SetIP = setIP.Text;
            }

            if(ched_PIN.IsChecked==true)
            {
                PIN=setPIN.Text;
            }
            else
            {
                Random random = new();
                string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                int LetterIndex = 0;
                for (int i = 0; i < 8; i++)
                {
                    LetterIndex = random.Next(36);
                    PIN += Letters[LetterIndex];
                }
            }

            SendResu.Message = $"设备配对码发送成功！设备配对码为：{PIN}";

            SendResu.IsOpen = true;

            Task.Run(async () =>
            {
                await LinkNewModule.StartLinking(SetIP, PIN);
            });
        }
    }
}
