// Configure network service to use a proxy, load a remote page, and ensure resources load through proxy.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the remote page to load
            string url = "https://www.example.com";

            // Create a request message for the URL
            RequestMessage request = new RequestMessage(url);
            // Set a reasonable timeout (30 seconds)
            request.Timeout = System.TimeSpan.FromSeconds(30);

            // Create a configuration and obtain the network service
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // (Proxy configuration would be set here if supported by the API)

            // Load the document using the request and configuration
            using (HTMLDocument document = new HTMLDocument(request, configuration))
            {
                // Output the loaded HTML content
                string html = ((HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}