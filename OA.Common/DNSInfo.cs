using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace  Common2
{
    public class DNSInfo
    {
        public static string GetIPAdress()
        {
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
    }
}
