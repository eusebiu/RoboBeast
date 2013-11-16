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

        [DataMember]
        public int Backward { get; set; }

        public override string ToString()
        {
            return string.Format("Forward:{0}, Backward:{1}",Forward,Backward);
        }
    }
}
