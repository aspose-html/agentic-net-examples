// Load HTML content from a URL stream while specifying a custom user‑agent header for the request.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the HTML page to load
            string url = "https://example.com";

            // Create a request message and set a custom User-Agent header
            RequestMessage request = new RequestMessage(url);
            request.Headers["User-Agent"] = "MyCustomUserAgent/1.0";

            // Load the HTML document using the request with the custom header
            using (HTMLDocument document = new HTMLDocument(request))
            {
                // Document is now loaded and can be processed further
                Console.WriteLine("HTML document loaded successfully.");
                Console.WriteLine("Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}