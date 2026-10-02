// Create an HTML document, embed a base tag, and verify relative URLs resolve correctly.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><base href=\"https://example.com/subdir/\"/></head><body><img src=\"images/pic.png\"/></body></html>";
            // Load the HTML from a string; provide a placeholder base URI.
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Retrieve all <img> elements.
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            if (images.Length > 0)
            {
                Aspose.Html.Dom.Element imageElement = images[0];
                string src = imageElement.GetAttribute("src");

                // Resolve the relative URL against the document's base URI.
                Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(src, document.BaseURI);

                Console.WriteLine("Original src attribute: " + src);
                Console.WriteLine("Resolved absolute URL: " + resolvedUrl.ToString());
            }
            else
            {
                Console.WriteLine("No <img> elements found in the document.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}