using RoboBeast.Common;
using RoboBeast.Common.Interface;
using Sharpduino;
using Sharpduino.Constants;
using System;
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

        static ConcurrentDictionary<string, ArduinoUno> cache = new ConcurrentDictionary<string, ArduinoUno>();

        public bool Register(string clientName)
        {
            if (cache.ContainsKey(clientName))
                return false;

            Console.WriteLine("Register client: " + clientName);

            var arduino = Arduino.ArduinoFactory.CreateArduino(Port);
            cache.AddOrUpdate(clientName, arduino, (c, s) => arduino);

            return true;
        }
        
        public void SendData(string clientName, Data data)
        {
            if (!cache.ContainsKey(clientName))
                return;

            ArduinoUno arduino = cache[clientName];
            System.Console.WriteLine(data);
            //queue.Enqueue(data);
            arduino.SetDO(ArduinoUnoPins.A1, data.Led);

            arduino.SetPWM(ArduinoUnoPWMPins.D3_PWM, data.LeftMotor.Forward);
            arduino.SetPWM(ArduinoUnoPWMPins.D5_PWM, data.LeftMotor.Backward);

            arduino.SetPWM(ArduinoUnoPWMPins.D6_PWM, data.RightMotor.Forward);
            arduino.SetPWM(ArduinoUnoPWMPins.D9_PWM, data.RightMotor.Backward);
        }

        public bool IsArduinoConnected(string clientName)
        {
            if (!cache.ContainsKey(clientName))
                return false;

            ArduinoUno arduino = cache[clientName];
            return arduino.IsInitialized;
        }

        public bool IsKinectConnected(string clientName)
        {
            return true;
        }
    }
}
