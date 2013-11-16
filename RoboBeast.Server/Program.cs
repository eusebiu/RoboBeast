using Firmata.NET;
using Sharpduino;
using Sharpduino.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoboBeast.Server
{
    class Program
    {
        static string Port = ConfigurationSettings.AppSettings["Port"];

        static void Main(string[] args)
        {
            try
            {
                using (ArduinoUno arduino = new ArduinoUno(Port))
                {
                    while (!arduino.IsInitialized) ;

                    arduino.SetPinMode(ArduinoUnoPins.A5, PinModes.Analog);
                    arduino.SetPinMode(ArduinoUnoPins.A1, PinModes.Output);

                    arduino.SetDO(ArduinoUnoPins.A1, false);

                    arduino.SetPinMode(ArduinoUnoPins.D3_PWM, PinModes.PWM);
                    arduino.SetPinMode(ArduinoUnoPins.D5_PWM, PinModes.PWM);

                    arduino.SetPinMode(ArduinoUnoPins.D6_PWM, PinModes.PWM);
                    arduino.SetPinMode(ArduinoUnoPins.D9_PWM, PinModes.PWM);

                    while (true)
                    {
                        var distance = arduino.ReadAnalog(ArduinoUnoAnalogPins.A5);
                        Console.WriteLine(distance);

                        distance = Math.Max(distance, 200);

                        arduino.SetPWM(ArduinoUnoPWMPins.D3_PWM, 200);

                        if (distance != -1)
                            Thread.Sleep((int)distance);

                        arduino.SetPWM(ArduinoUnoPWMPins.D3_PWM, -200);
                        if (distance != -1)
                            Thread.Sleep((int)distance);
                    }                     
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
