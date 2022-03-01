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
            Console.WriteLine(Status.vendorName);
            
        }
    }
}