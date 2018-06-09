using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MacAddresses
{
    class Program
    {
        static void Main(string[] args)
        {
            var macAddresses = GetMac();
            Console.WriteLine("{0} Found {1} Macaddresses:", Environment.MachineName,  macAddresses.Count);
            var i = 1;
            foreach (var macAddress in macAddresses)
            {
                Console.WriteLine("Macaddress {0}: {1}", i++, macAddress);
            }
            using (var sw = new StreamWriter("logmacaddresses.txt", true))
            {
                sw.WriteLine("{0} Found {1} Macaddresses:", Environment.MachineName, macAddresses.Count);
                i = 1;
                foreach (var macAddress in macAddresses)
                {
                    sw.WriteLine("Macaddress {0}: {1}", i++, macAddress);
                }                
            }
        }


        static private List<string> GetMac()
        {
            NetworkInterface[] NetworkAdapters = NetworkInterface.GetAllNetworkInterfaces();
            List<string> MyAdapter = new List<string>();

            foreach (NetworkInterface adapter in NetworkAdapters)
            {
                MyAdapter.Add("Adapter: " + adapter.NetworkInterfaceType + " description " + adapter.Description + " / MAC: " + adapter.GetPhysicalAddress().ToString());
            }

            return MyAdapter;
        }
    }
}
