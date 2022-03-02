using System;
using libHitron2;


namespace libHitronClient
{
    class Program
    {
        static void Main(string[] args)
        {
            libHitron2.Authentication hitron = new Authentication();
            hitron.ConnectAndLogin("cusadmin", "password"); 
            // Testing Modem is configured with the default username and password
            libHitron2.Status status = new Status();
            var Status = status.System_Information();
            Console.WriteLine("Vendor: " + Status.vendorName);
            var docsisProvisioning = status.Docsis_Provisioning();
            Console.WriteLine("Registration: " + docsisProvisioning.registration);
            var DOCIS_WAN_GENERAL = status.Docsis_WAN_General();
            Console.WriteLine("WAN IP: " + DOCIS_WAN_GENERAL.ip[0]);
            
        }
    }
}