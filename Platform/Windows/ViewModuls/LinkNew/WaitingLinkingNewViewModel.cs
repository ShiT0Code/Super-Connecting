using DevicesInterconnection.CS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesInterconnection.ViewModuls.LinkNew
{
    public class WaitingLinkingNewData
    {
        public string PIN { get; set; }
        public string SendTime { get; set; }
        public string Name { get; set; }
        public string DeviceType{ get; set; }
        public string Brand { get; set; }
        public string OS { get; set; }
    }

    public class WaitingLinkingNewViewModel
    {
        private ObservableCollection<WaitingLinkingNewData> waitingLinkingNewDatas = new();
        public ObservableCollection<WaitingLinkingNewData> WLNViewModel 
        {
            get
            { 
                return waitingLinkingNewDatas;
            }
        }
        public WaitingLinkingNewViewModel()
        {
            waitingLinkingNewDatas.Add(new WaitingLinkingNewData()
            {
                Name = "L",
                PIN = "123",
                DeviceType = "PC",
                Brand = "Unknow",
                SendTime = "2024/8/21 20:00:00",
                OS = "Microsoft Windows 11 Pro"
            });
        }
    }

    public class LinkNewViewModel
    {
        public WaitingLinkingNewViewModel ViewModelWLN1 { get; set; }

        public LinkNewViewModel()
        {
            ViewModelWLN1 = new WaitingLinkingNewViewModel();

            ViewModelWLN1.WLNViewModel.Add(new WaitingLinkingNewData()
            {
                Name = "D",
                PIN = "ABCD",
                DeviceType = "Phone",
                Brand = "Apple",
                SendTime = "2024/8/21 20:00:00",
                OS = "Microsoft Windows 12 Pro"
            });
        }

        public async Task CollectingDevices()
        {

            while (true)
            {
                await Task.Delay(1500);
                string CollectedInfo = await NetworkModule.InNetReceiveReplies(12568);

                if (CollectedInfo.StartsWith("Error"))
                {
                    continue;
                }

                string[] KeyWords = CollectedInfo.Split(',');

                string type = KeyWords[0];

                if (type == "B" || type == "C")
                {
                    continue;
                }
            }
        }
    }
}
