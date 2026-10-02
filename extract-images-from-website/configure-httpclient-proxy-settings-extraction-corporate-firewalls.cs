// Configure HttpClient with proxy settings to support extraction behind corporate firewalls.

using System;
using System.Net;
using System.Net.Http;

class Program
{
    static void Main()
    {
        try
        {
            // Configure proxy
            var proxy = new WebProxy("http://proxy.example.com:8080");
            var httpHandler = new HttpClientHandler
            {
                Proxy = proxy,
                UseProxy = true
            };

            using (var httpClient = new HttpClient(httpHandler))
            {
                string url = "https://example.com";
                string htmlContent = httpClient.GetStringAsync(url).Result;

                // Load HTML content with Aspose.HTML
                var configuration = new Aspose.Html.Configuration();
                using (var document = new Aspose.Html.HTMLDocument(htmlContent, url, configuration))
                {
                    // Save the document to a file
                    document.Save("output.html");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}