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
        const string CLIENTNAME = "Kinect";

        static RoboClient()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress address = new EndpointAddress(ConfigurationManager.AppSettings["ServerAddress"]);

            var factory =
                new ChannelFactory<IRoboInterface>(binding, address);

            channel = factory.CreateChannel();
            channel.Register(CLIENTNAME);
        }

        public static void SendData(Skeleton skeleton)
        {
            var now = DateTime.Now;
            if (now.Subtract(_prevTime).TotalMilliseconds < 600)
                return;

            _prevTime = DateTime.Now;
            //KinectAudioSource.MaxBeamAngle.ToString();
            
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

            float manaR=0, manaL=0;
            float fi=0.09f;
            int ct = 170;//constanta motoare inainte
            int ct2 = -150;//constatnta motoare inapoi

            manaR=handRight.Position.Y-shoulderRight.Position.Y;
            manaL = -(handLeft.Position.Y - shoulderLeft.Position.Y);                

            if(Math.Abs(manaR)<fi&&Math.Abs(manaL)<fi)
            {
                motorLB = motorLF = motorRB = motorRF = 0;
            }
            else 
                if (Math.Abs(manaR) < fi && Math.Abs(manaL)>=fi)
                {
                    if (manaL > 0) { motorLB = motorRB = motorRF = 0; motorLF = (int)(manaL * ct); led = true; }
                    else { motorLF = motorRB = motorRF = 0; motorLB = (int)(manaL * ct2); led = true; }
                }
                else
                {
                    if(Math.Abs(manaL)<fi && Math.Abs(manaR)>=fi)
                    {
                        if (manaR > 0) { motorLB = motorRB = motorLF = 0; motorRF = (int)(manaR * ct); led = true; }
                        else { motorLF = motorLB = motorRF = 0; motorRB = (int)(manaR * ct2); led = true; }
                    }
                    else
                    {
                        if(manaL<0&&manaR<0)
                        {
                            motorRF = motorLF = 0;
                            motorLB = (int)(manaL * ct2);
                            motorRB = (int)(manaR * ct2);
                            led = true;
                        }
                        else
                        {
                            if(manaL<0&&manaR>0)
                            {
                                motorRF = (int)(manaR * ct);
                                motorLB = (int)(manaL * ct2);
                                motorLF = motorRB = 0;
                                led = true;
                            }
                            else
                            {
                                if(manaL>0&&manaR<0)
                                {
                                    motorLF=(int)(manaL*ct);
                                    motorLB = motorRF = 0;
                                    motorRB = (int)(manaR * ct2);
                                    led = true;
                                }
                                else
                                {
                                    motorRB = motorLB = 0;
                                    motorLF = (int)(manaL * ct);
                                    motorRF = (int)(manaR * ct);
                                    led = true;
                                }
                            }
                        }
                    }
                }

            //Debug.WriteLine(string.Format("Left hand: {0},{1},{2}", handLeft.Position.X, handLeft.Position.Y, handLeft.Position.Z));
            //Debug.WriteLine(string.Format("Right hand: {0},{1},{2}", handRight.Position.X, handRight.Position.Y, handRight.Position.Z));
            Debug.WriteLine("manaR:" + manaR.ToString() + " - " + "manaL:" + manaL.ToString());
            //Debug.WriteLine("manaL:" + manaL.ToString());

            channel.SendData(CLIENTNAME, new Data
            {
                Led = led,
                LeftMotor = new Motor { Forward = motorLF, Backward = motorLB },
                RightMotor = new Motor { Forward = motorRF, Backward = motorRB }
            });
        }        
    }
}
