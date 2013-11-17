using Sharpduino;
using Sharpduino.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBeast.Server.Arduino
{
    static class ArduinoFactory
    {
        public static ArduinoUno CreateArduino(string port)
        {
            var arduino = new ArduinoUno(port);

            while (!arduino.IsInitialized) ;

            Console.WriteLine("Arduino initialized...");

            arduino.SetPinMode(ArduinoUnoPins.A5, PinModes.Analog);
            arduino.SetPinMode(ArduinoUnoPins.A1, PinModes.Output);

            arduino.SetDO(ArduinoUnoPins.A1, false);

            arduino.SetPinMode(ArduinoUnoPins.D3_PWM, PinModes.PWM);
            arduino.SetPinMode(ArduinoUnoPins.D5_PWM, PinModes.PWM);

            arduino.SetPinMode(ArduinoUnoPins.D9_PWM, PinModes.PWM);
            arduino.SetPinMode(ArduinoUnoPins.D6_PWM, PinModes.PWM);

            return arduino;
        }        
    }
}
