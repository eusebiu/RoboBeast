using RoboBeast.Common;
using System.ServiceModel;

namespace RoboBeast.Common.Interface
{
    [ServiceContract]
    public interface IRoboInterface
    {
        [OperationContract (IsOneWay=true)]
        void SendData(Data data);

        [OperationContract]
        bool IsArduinoConnected();

        [OperationContract]
        bool IsKinectConnected();
    }
}
