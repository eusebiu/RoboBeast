using System;
using System.Configuration;
using System.ServiceModel;

namespace RoboBeast.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(RoboService)))
            {
                host.Open();

                Console.WriteLine("Press <Enter> to stop the service");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
