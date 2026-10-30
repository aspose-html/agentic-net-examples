// Create an HTML document, embed a base tag, and verify relative URLs resolve correctly.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Inline HTML with a <base> tag and a relative image URL
            string htmlContent = "<!DOCTYPE html><html><head><base href=\"https://example.com/subdir/\"/></head><body><img src=\"images/pic.png\"/></body></html>";

            // Load the HTML content. Use a placeholder base URI because the content is inline.
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Retrieve the first <img> element
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            if (images.Length == 0)
            {
                Console.WriteLine("No <img> elements found.");
                return;
            }

            Aspose.Html.Dom.Element imgElement = images[0];
            string srcAttribute = imgElement.GetAttribute("src");

            // Resolve the relative URL against the document's BaseURI (which takes the <base> tag into account)
            Aspose.Html.Url resolvedUrl = new Aspose.Html.Url(srcAttribute, document.BaseURI);

            Console.WriteLine("Original src attribute: " + srcAttribute);
            Console.WriteLine("Resolved absolute URL: " + resolvedUrl.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}