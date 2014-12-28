using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        string Echo(string input);
    }
}
