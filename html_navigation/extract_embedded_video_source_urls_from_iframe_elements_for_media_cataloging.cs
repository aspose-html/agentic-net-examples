// Extract embedded video source URLs from iframe elements for the media cataloging.

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
            // Load the HTML document from a file or URL
            HTMLDocument document = new HTMLDocument("input.html");

            // Get all iframe elements
            var iframes = document.GetElementsByTagName("iframe");

            // Iterate through each iframe and extract the src attribute
            foreach (Element iframe in iframes)
            {
                string src = iframe.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Resolve to an absolute URL using the document's base URI
                Url absoluteUrl = new Url(src, document.BaseURI);
                Console.WriteLine(absoluteUrl.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}