// Set a timeout on HttpClient to prevent hanging during external SVG download.

using System;
using Aspose.Html.Net;
using Aspose.Html;

namespace SvgDownloader
{
    class Program
    {
        static void Main()
        {
            try
            {
                // URL of the external SVG
                string url = "https://example.com/sample.svg";

                // Create a request message and set a timeout of 30 seconds
                RequestMessage request = new RequestMessage(url);
                request.Timeout = TimeSpan.FromSeconds(30);

                // Load the SVG document using the request with the timeout applied
                HTMLDocument document = new HTMLDocument(request);

                // Retrieve the SVG markup as a string
                string svgContent = ((HTMLElement)document.DocumentElement).OuterHTML;

                Console.WriteLine(svgContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}