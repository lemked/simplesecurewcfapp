using System;

namespace Service
{
    public class WcfService : IWcfService
    {
        public string Echo(string input)
        {
            return String.Format("You've entered: {0}", input);
        }
    }
}
