﻿using System;
using System.ServiceModel;

using Service;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = new EndpointAddress(new Uri("http://localhost:9000/MyService"));
            var binding = new BasicHttpBinding();
            var factory = new ChannelFactory<IWcfService>(binding, address);

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