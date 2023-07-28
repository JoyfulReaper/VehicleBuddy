using System.Net.Http.Headers;
using System.Net.Http;
using VehicleBuddy.ApiClient.Common.Options;

namespace VehicleBuddy.ApiClient.Common
{
    internal class ApiClientConfigurationHelper
    {
        internal static void ConfigureHttpClient(HttpClient client, VehicleBuddyClientOptions options)
        {
            client.BaseAddress = new Uri(options.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(HttpClientConstants.UserAgent, HttpClientConstants.Version));
        }
    }
}