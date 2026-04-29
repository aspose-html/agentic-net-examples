// Configure a timeout for the RequestMessage to avoid hanging.

using System;
using Aspose.Html;
using Aspose.Html.Net;

namespace TimeoutExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // URL to load
                string url = "https://example.com";

                // Create request message with a custom timeout
                RequestMessage request = new RequestMessage(url);
                request.Timeout = TimeSpan.FromSeconds(30); // 30‑second timeout

                // Load the HTML document using the request
                using (HTMLDocument document = new HTMLDocument(request))
                {
                    // Get a snippet of the loaded HTML
                    string html = ((HTMLElement)document.DocumentElement).OuterHTML;
                    Console.WriteLine("Loaded HTML snippet:");
                    Console.WriteLine(html.Length > 200 ? html.Substring(0, 200) + "..." : html);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}