// Resolve relative URLs to absolute URLs using the Url class and the document BaseURI.

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
            // Load the HTML document from a URL (base URI will be set automatically)
            HTMLDocument document = new HTMLDocument("https://example.com/page.html");

            // Retrieve all <img> elements in the document
            HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate through each image element
            for (int i = 0; i < images.Length; i++)
            {
                // Cast the collection item to an Element
                Element imageElement = (Element)images[i];

                // Get the value of the src attribute
                string src = imageElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Resolve the src (which may be relative) to an absolute URL using the document's BaseURI
                Url absoluteUrl = new Url(src, document.BaseURI);

                // Output the resolved absolute URL
                Console.WriteLine(absoluteUrl.ToString());
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}