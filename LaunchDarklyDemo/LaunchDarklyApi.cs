using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LaunchDarklyDemo
{
    public static class LaunchDarklyApi
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task GetUsers()
        {
            client.BaseAddress = new Uri("https://app.launchdarkly.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "api-66be39c1-f460-49ea-adef-d23a7c08569b");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync("/api/v2/user-search/support-service/mtempleton");

            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}