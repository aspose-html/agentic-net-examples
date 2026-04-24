// Implement a configurable timeout for HttpClient requests to avoid hanging on slow resources.

using System;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the remote resource
            string url = "https://example.com";

            // Configurable timeout in seconds
            int timeoutSeconds = 30;

            // Create a request message for the URL
            RequestMessage request = new RequestMessage(url);

            // Set the timeout for the request
            request.Timeout = TimeSpan.FromSeconds(timeoutSeconds);

            // Load the HTML document using the request with the custom timeout
            HTMLDocument document = new HTMLDocument(request);

            // Output the outer HTML of the loaded document
            Console.WriteLine(document.DocumentElement.OuterHTML);
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during loading
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}