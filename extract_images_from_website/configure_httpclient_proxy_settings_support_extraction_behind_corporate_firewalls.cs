// Configure HttpClient with proxy settings to support extraction behind corporate firewalls.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsposeHtmlProxyExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Configure proxy settings for corporate firewall
                var proxy = new WebProxy("http://proxy.company.com:8080")
                {
                    // If authentication is required, set credentials here
                    // Credentials = new NetworkCredential("username", "password")
                };

                var handler = new HttpClientHandler
                {
                    Proxy = proxy,
                    UseProxy = true,
                    // Optional: bypass proxy for local addresses
                    // BypassProxyOnLocal = true
                };

                // Create HttpClient with the configured handler
                using var httpClient = new HttpClient(handler);

                // Example request to fetch an HTML page
                var requestUrl = "https://example.com";
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Page content length: " + content.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}