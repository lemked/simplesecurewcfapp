using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WcfService)))
            {
                var address = new Uri("https://localhost:9000/MyService");
                var binding = new BasicHttpsBinding(BasicHttpsSecurityMode.TransportWithMessageCredential);
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

                host.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
                host.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new CredentialsValidator();

                // Attach a Certificate from the Certificate Store to the HTTP Binding
                string certThumbprint = "a5394ac183ef41da4ac99856de426087267e9f64";
                host.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, certThumbprint);

                host.AddServiceEndpoint(typeof(IWcfService), binding, address);

                host.Open();

                Console.WriteLine("Service started, press any key to finish execution.");
                Console.ReadKey();

                host.Close();
            }
        }
    }
}
