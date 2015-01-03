using System;
using System.ServiceModel;
using System.ServiceModel.Security;
using Service;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter server address: ");
            var hostAddress = Console.ReadLine();

            var address = new EndpointAddress(new Uri(string.Format("https://{0}:9000/MyService", hostAddress)));
            var binding = new BasicHttpsBinding(BasicHttpsSecurityMode.TransportWithMessageCredential);
            var factory = new ChannelFactory<IWcfService>(binding, address);

            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            factory.Credentials.UserName.UserName = username;

            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            factory.Credentials.UserName.Password = password;

            IWcfService host = factory.CreateChannel();

            Console.WriteLine("Please enter some words or press [Esc] to exit the application.");

            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key.Equals(ConsoleKey.Escape))
                {
                    return;
                }

                string input = key.KeyChar.ToString() + Console.ReadLine(); // read input

                string output = host.Echo(input); // send to host, receive output
                Console.WriteLine(output); // write output
            }
        }
    }
}
