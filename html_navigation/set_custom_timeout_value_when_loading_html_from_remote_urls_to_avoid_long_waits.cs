// Set a custom timeout value when loading HTML from remote URLs to avoid long waits.

using System;
using Aspose.Html;
using Aspose.Html.Net;

namespace CustomTimeoutExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // URL of the remote HTML page
                string url = "https://example.com";

                // Create a request message for the URL
                RequestMessage request = new RequestMessage(url);

                // Set a custom timeout of 30 seconds
                request.Timeout = TimeSpan.FromSeconds(30);

                // Load the HTML document using the request with the custom timeout
                HTMLDocument document = new HTMLDocument(request);

                // Retrieve the outer HTML of the document's root element
                string html = ((HTMLElement)document.DocumentElement).OuterHTML;

                Console.WriteLine(html);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}