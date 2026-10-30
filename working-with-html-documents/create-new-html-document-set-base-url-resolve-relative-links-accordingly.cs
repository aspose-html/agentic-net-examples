// Create a new HTML document, set its base URL, and resolve relative links accordingly.

using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Sample HTML with a relative link
                string html = "<html><body><a href=\"page2.html\">Link</a></body></html>";
                // Base URL to resolve relative links against
                string baseUrl = "https://example.com/";

                // Create HTML document with base URL
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);

                // Get the first anchor element
                Aspose.Html.Collections.HTMLCollection anchors = document.GetElementsByTagName("a");
                if (anchors.Length > 0)
                {
                    Aspose.Html.HTMLElement anchor = anchors[0] as Aspose.Html.HTMLElement;
                    string relativeHref = anchor.GetAttribute("href");

                    // Resolve the relative URL against the document's base URI
                    Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(relativeHref, document.BaseURI);
                    Console.WriteLine("Relative href: " + relativeHref);
                    Console.WriteLine("Resolved absolute URL: " + resolvedUrl.Href);
                }

                // Save the document to a file
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Document saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}