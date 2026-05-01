// Load an HTML document from a URL using custom network timeout, and handle timeout exceptions gracefully.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the HTML page to load
            string url = "https://example.com";

            // Create a request message with the target URL
            RequestMessage request = new RequestMessage(url);

            // Set a custom timeout (10 seconds)
            request.Timeout = System.TimeSpan.FromSeconds(10);

            // Load the HTML document using the request message
            HTMLDocument document = new HTMLDocument(request);

            // Extract the outer HTML of the document
            string html = ((HTMLElement)document.DocumentElement).OuterHTML;

            // Output the loaded HTML
            Console.WriteLine(html);
        }
        catch (Exception ex)
        {
            // Handle timeout or other network errors gracefully
            if (ex.Message.Contains("timed out"))
            {
                Console.WriteLine("Request timed out.");
            }
            else
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}