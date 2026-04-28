// Replace all occurrences of non‑breaking space characters with regular spaces for text normalization.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing non‑breaking spaces (U+00A0)
            string htmlContent = "<html><body><p>Hello&nbsp;World! This is a test.</p></body></html>";
            string baseUri = "http://example.com";

            // Load the HTML into an Aspose.HTML document
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Get the inner HTML of the body, replace non‑breaking spaces with regular spaces
            string bodyHtml = document.Body.InnerHTML;
            string normalizedBodyHtml = bodyHtml.Replace('\u00A0', ' ');

            // Set the normalized HTML back to the document
            document.Body.InnerHTML = normalizedBodyHtml;

            // Save the normalized document
            document.Save("normalized.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}