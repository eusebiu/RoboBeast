using RoboBeast.Common;
using RoboBeast.Common.Interface;
using Sharpduino;
using Sharpduino.Constants;
using System.Collections.Concurrent;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace RoboBeast.Server
{
    public class RoboService : IRoboInterface
    {
        CancellationToken ct = new CancellationToken();

        static string Port = ConfigurationManager.AppSettings["Port"];

        ArduinoUno arduino = Arduino.ArduinoFactory.CreateArduino(Port);

        ConcurrentQueue<Data> queue = new ConcurrentQueue<Data>();

        public RoboService()
        {
            //Task.Factory.StartNew(() => Process());
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
                        arduino.SetPWM(ArduinoUnoPWMPins.D9_PWM, data.RightMotor.Backward);
                    }
                }

                var distance = arduino.ReadAnalog(ArduinoUnoAnalogPins.A5);

                //if (distance < 100)
                //{
                //    arduino.SetPWM(ArduinoUnoPWMPins.D3_PWM, 0);
                //    arduino.SetPWM(ArduinoUnoPWMPins.D5_PWM, 0);

                //    arduino.SetPWM(ArduinoUnoPWMPins.D6_PWM, 0);
                //    arduino.SetPWM(ArduinoUnoPWMPins.D9_PWM, 0);
                //}
            }
        }

        public void SendData(Data data)
        {
            System.Console.WriteLine(data);
            //queue.Enqueue(data);
            arduino.SetDO(ArduinoUnoPins.A1, data.Led);

            arduino.SetPWM(ArduinoUnoPWMPins.D3_PWM, data.LeftMotor.Forward);
            arduino.SetPWM(ArduinoUnoPWMPins.D5_PWM, data.LeftMotor.Backward);

            arduino.SetPWM(ArduinoUnoPWMPins.D6_PWM, data.RightMotor.Forward);
            arduino.SetPWM(ArduinoUnoPWMPins.D9_PWM, data.RightMotor.Backward);
        }

        public bool IsArduinoConnected()
        {
            return arduino.IsInitialized;
        }

        public bool IsKinectConnected()
        {
            return true;
        }
    }
}
