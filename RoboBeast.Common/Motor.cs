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
        public int Direction { get; set; }

        public int Power { get; set; }
    }
}
