// Create an HTML document, embed a base tag, and verify relative URLs resolve correctly.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content with a <base> tag to set the base URL for relative links
            string htmlContent = "<!DOCTYPE html><html><head><base href=\"https://example.com/subdir/\"/></head><body><a href=\"page.html\">Link</a></body></html>";
            // Base URI supplied to the document constructor (used for resolving relative resources)
            string baseUri = "https://example.com/";

            // Create an HTMLDocument from the string content and base URI (rule: create-html-from-string)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Save the document to verify that the base tag is persisted
            document.Save("output.html");

            // Resolve a relative URL ("page.html") using the document's effective base URI
            Aspose.Html.Url resolvedUrl = new Aspose.Html.Url("page.html", document.BaseURI);

            // Output the absolute URL to confirm correct resolution
            Console.WriteLine("Resolved URL: " + resolvedUrl);
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}