// Open a web page using Aspose.HTML Document and extract raster images from <img> tags.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the web page to load
            string pageUrl = "https://example.com";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(pageUrl);

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate through each image element
            foreach (Element image in images)
            {
                // Retrieve the src attribute
                string src = image.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Resolve to an absolute URL using the document's base URI
                Url absoluteUrl = new Url(src, document.BaseURI);

                // Output the image URL
                Console.WriteLine(absoluteUrl.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}