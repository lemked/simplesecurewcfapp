using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WcfService)))
            {
                var address = new Uri("https://localhost:8999/MyService");
                var binding = new BasicHttpBinding();
                host.AddServiceEndpoint(typeof(IWcfService), binding, address);

                host.Open();

                Console.WriteLine("Service started, press any key to finish execution.");
                Console.ReadKey();

                host.Close();
            }
        }
    }
}
