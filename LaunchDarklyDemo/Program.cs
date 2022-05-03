using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Client;
using LaunchDarklyDemo;
using LaunchDarklyDemo.Models;

await LaunchDarklyDao.InitiateClient();
var user = new InsuranceCompanyUser();
var menu = "1";
while(menu != "0")
{
    switch(menu)
    {
        case "0":
        break;
        default:
        Console.WriteLine("Welcome to my fake insurance app");
        if(LaunchDarklyDao.ShouldEnableMotorcycleBundle(user) ?? false)
        {
            Console.WriteLine("Would you like to bundle motorcycle insurance? Enter 'y' for yes, any other key for no.");
            var enableMotorcycle = Console.ReadLine();
            if(enableMotorcycle == "y")
                LaunchDarklyDao.RegisterMotorcycleEvent();
        }
        Console.WriteLine("Press 0 to quit, any other key to continue");
        menu = Console.ReadLine();

        break;
    }
}


