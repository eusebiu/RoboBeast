using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RoboBeast.Common
{
    [DataContract]
    public class Data
    {
        [DataMember]
        public Motor LeftMotor { get; set; }

        [DataMember]
        public Motor RightMotor { get; set; }

        [DataMember]
        public bool Led { get; set; }
    }
}
