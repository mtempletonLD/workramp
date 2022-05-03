using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Client;
using LaunchDarklyDemo.Models;
using Newtonsoft.Json;
namespace LaunchDarklyDemo
{
    public static class LaunchDarklyDao
    {
        private static LdClient? client;
        private static User InitialUser = User.WithKey("initial_user");

        public static async Task InitiateClient()
        {
            client = await LdClient.InitAsync("YOUR KEY HERE", InitialUser);
        }
        
        public static bool? GetTestBool()
        {
            if(client != null)
            {
                return client.BoolVariation("test-bool", false);
            }
            return null;
        }

        internal static void RegisterMotorcycleEvent()
        {
            if(client != null)
            client.Track("Motorcycle Bundle Click-Through");
        }

        public static bool? ShouldEnableMotorcycleBundle(InsuranceCompanyUser userObject)
        {
            if(client != null)
            {
                var user = BuildUserObject(userObject);
                client.Identify(user, new TimeSpan(0, 0, 0, 5));
                return client.BoolVariation("motorcycle-bundle");
            }
            return null;
        }

        private static User BuildUserObject(InsuranceCompanyUser userObject)
        {            
            return User.Builder(Guid.NewGuid().ToString()).Custom("LoyaltyStatus", userObject.LoyaltyStatus).Custom("BundledPackages", JsonConvert.SerializeObject(userObject?.BundledPackages ?? null)).Build();
        }
    }
}
