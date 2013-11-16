using RoboBeast.Common;
using RoboBeast.Server.Interface;
using Sharpduino;
using Sharpduino.Constants;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoboBeast.Server
{
    public class RoboService : IRoboInterface
    {
        CancellationToken ct = new CancellationToken();

        static string Port = ConfigurationSettings.AppSettings["Port"];

        ArduinoUno arduino = Arduino.ArduinoFactory.CreateArduino(Port);

        ConcurrentQueue<Data> queue = new ConcurrentQueue<Data>();

        public RoboService()
        {
            Task.Factory.StartNew(() => Process());
        }

        private void Process()
        {
            while (!ct.IsCancellationRequested)
            {
                if (queue.Count > 0)
                {
                    Data data;
                    if (queue.TryDequeue(out data))
                    {
                        arduino.SetDO(ArduinoUnoPins.A1, data.Led);

                        arduino.SetPWM(ArduinoUnoPWMPins.D3_PWM, data.LeftMotor.Forward);
                        arduino.SetPWM(ArduinoUnoPWMPins.D5_PWM, data.LeftMotor.Backward);

                        arduino.SetPWM(ArduinoUnoPWMPins.D6_PWM, data.RightMotor.Forward);
                        arduino.SetPWM(ArduinoUnoPWMPins.D9_PWM, data.LeftMotor.Backward);
                    }
                }

                var distance = arduino.ReadAnalog(ArduinoUnoAnalogPins.A5);

                if (distance < 100)
                {
                    arduino.SetPWM(ArduinoUnoPWMPins.D3_PWM, 0);
                    arduino.SetPWM(ArduinoUnoPWMPins.D5_PWM, 0);

                    arduino.SetPWM(ArduinoUnoPWMPins.D6_PWM, 0);
                    arduino.SetPWM(ArduinoUnoPWMPins.D9_PWM, 0);
                }
            }
        }

        public void SendData(int leftForward, int leftBackWard, int rightForward, int rightBackward, bool light)
        {
            var data = new Data {
                Led = light,
                LeftMotor = new Motor { Forward = leftForward, Backward = leftBackWard },
                RightMotor = new Motor { Forward = rightForward, Backward = rightBackward } 
            };

            queue.Enqueue(data);
        }
    }
}
