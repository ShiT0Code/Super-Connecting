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
            foreach(List<string> strings in LinkNewModule.CollectInfos)
            {
                waitingLinkingNewDatas.Add(new WaitingLinkingNewData()
                {
                    Name = strings[0],
                    PIN = strings[1],
                    DeviceType = strings[2],
                    Brand = strings[3],
                    SendTime = strings[4],
                    OS = strings[5]
                });
            }
        }
    }
}
