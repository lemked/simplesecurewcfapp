using System;

namespace Service
{
    public class WcfService : IWcfService
    {
        public string Echo(string input)
        {
            Console.WriteLine("Received from client: {0}", input);
            return input;
        }
    }
}
