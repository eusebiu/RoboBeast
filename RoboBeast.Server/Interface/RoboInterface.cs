using RoboBeast.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RoboBeast.Server.Interface
{
    [ServiceContract]
    public interface RoboInterface
    {
        [OperationContract(IsOneWay = true)]
        public void SendData(Data data);

        public void RegisterClient(string clientName);
    }
}
