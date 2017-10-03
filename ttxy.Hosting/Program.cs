using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ttxy.Host
{
    class Program
    {
        static void Main (string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ttxyService)))
            {
                host.Open();
                Console.WriteLine("119CRT Service Address: ");
                foreach (var endpoint in host.Description.Endpoints)
                {
                    Console.WriteLine(endpoint.Address.ToString());
                }
                Console.WriteLine("119CRT Service Started, Press any key to stop service...");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
