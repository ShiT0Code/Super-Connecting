using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperConnecting_Windows.Backend.App;

public class NetworkModule
{
    public static async string SendMessage(string module,string to,string toExp,string message)
    {
        string SendedMessage =
            "{SupConMes[to:\"" + to + "\",to_exp:\"" + toExp + 
            "\"module:\"" + module + "\",message:\"" + message + "\"}";

        return "";
    }

}
