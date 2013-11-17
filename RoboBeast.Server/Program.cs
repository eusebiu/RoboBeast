using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace RoboBeast.Server
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost host = new ServiceHost(typeof(RoboService)))
            {
                // Check to see if the service host already has a ServiceMetadataBehavior
                ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                // If not, add one
                if (smb == null)
                    smb = new ServiceMetadataBehavior();

                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                host.AddServiceEndpoint(
                  ServiceMetadataBehavior.MexContractName,
                  MetadataExchangeBindings.CreateMexHttpBinding(),
                  "mex"
                );

                host.Open();

                Console.WriteLine("Press <Enter> to stop the service");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
