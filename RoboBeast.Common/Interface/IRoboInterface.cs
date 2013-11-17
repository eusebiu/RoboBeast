using RoboBeast.Common;
using System.ServiceModel;

namespace RoboBeast.Common.Interface
{
    [ServiceContract]
    public interface IRoboInterface
    {
        [OperationContract]
        bool Register(string clientName);

        [OperationContract (IsOneWay=true)]
        void SendData(string clientName, Data data);

        [OperationContract]
        bool IsArduinoConnected(string clientName);

        [OperationContract]
        bool IsKinectConnected(string clientName);
    }
}
