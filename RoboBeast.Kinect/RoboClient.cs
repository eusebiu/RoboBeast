using Microsoft.Kinect;
using RoboBeast.Common;
using RoboBeast.Common.Interface;
using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceModel;

namespace RoboBeast.Kinect
{
    static class RoboClient
    {
        static System.DateTime _prevTime = DateTime.Now;
        static IRoboInterface channel;

        static RoboClient()
        {
            NetTcpBinding binding = new NetTcpBinding();
            EndpointAddress address = new EndpointAddress(ConfigurationManager.AppSettings["ServerAddress"]);

            var factory =
                new ChannelFactory<IRoboInterface>(binding, address);

            channel = factory.CreateChannel();
        }

        public static void SendData(Skeleton skeleton)
        {
            var now = DateTime.Now;
            if (now.Subtract(_prevTime).TotalMilliseconds < 600)
                return;

            _prevTime = DateTime.Now;

            Joint handRight = skeleton.Joints[JointType.HandRight];
            Joint handLeft = skeleton.Joints[JointType.HandLeft];
            Joint shoulderRight = skeleton.Joints[JointType.ShoulderRight];
            Joint shoulderLeft = skeleton.Joints[JointType.ShoulderLeft];
            Joint hipLeft = skeleton.Joints[JointType.HipLeft];
            Joint hipRight = skeleton.Joints[JointType.HipRight];
            Joint kneeLeft = skeleton.Joints[JointType.KneeLeft];
            Joint head = skeleton.Joints[JointType.Head];
            

            int motorLF=0, motorLB=0, motorRF=0, motorRB=0;
            bool led=false;

            Debug.WriteLine(string.Format("Left hand: {0},{1},{2}", handLeft.Position.X, handLeft.Position.Y, handLeft.Position.Z));
            Debug.WriteLine(string.Format("Right hand: {0},{1},{2}", handRight.Position.X, handRight.Position.Y, handRight.Position.Z));

            if (handRight.Position.Y > shoulderRight.Position.Y)
            {
                motorRF = 120;
                motorLF = 0;
            }

            if (handLeft.Position.Y > shoulderLeft.Position.Y)
            {
                motorLF = 120;
                motorRF = 0;
            }
            if ((handRight.Position.Y > shoulderRight.Position.Y) && (handLeft.Position.Y > shoulderLeft.Position.Y))
            {
                motorLF = 120;
                motorRF = 120;
                led = true;
            }
            if ((handLeft.Position.Y < hipLeft.Position.Y) && (handRight.Position.Y < hipRight.Position.Y))
            {
                motorLF = -120;
                motorRF = -120;
                led = true;
            }
            if (handRight.Position.Y <hipRight.Position.Y)
            {
                motorRB = -120;
                motorRF = 0;
            }
            if (handLeft.Position.Y < hipLeft.Position.Y)
            {
                motorLB = -120;
                motorRB = 0;
            }
            //if (handRight.Position.Y == head.Position.Y)
            //{
            //    led = true;
            //}

            channel.SendData(new Data
            {
                Led = led,
                LeftMotor = new Motor { Forward=motorLF,Backward=motorLB },
                RightMotor = new Motor { Forward = motorRF, Backward = motorRB }
            });
        }        
    }
}
