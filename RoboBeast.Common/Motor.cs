using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace RoboBeast.Common
{
    [DataContract]
    public sealed class Motor
    {
        [DataMember]
        public int Forward { get; set; }

        public int Backward { get; set; }
    }
}
