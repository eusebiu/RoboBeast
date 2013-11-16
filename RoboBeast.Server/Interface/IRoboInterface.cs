using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RoboBeast.Server.Interface
{
    [ServiceContract]
    public interface IRoboInterface
    {
        [OperationContract (IsOneWay=true)]
        void SendData(int leftForward, int leftBackWard, int rightForward, int rightBackward, bool light);
    }
}
