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
}
