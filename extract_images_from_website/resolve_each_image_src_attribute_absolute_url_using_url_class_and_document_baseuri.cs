// Resolve each image src attribute to an absolute URL using Url class and document BaseURI.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;
using Aspose.Html.Net;

namespace ResolveImageSrc
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path or URL to the HTML document
                string htmlPath = "sample.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Get all <img> elements
                HTMLCollection images = document.GetElementsByTagName("img");

                // Iterate through each image and resolve its src attribute to an absolute URL
                for (int i = 0; i < images.Length; i++)
                {
                    Element imageElement = (Element)images[i];
                    string src = imageElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;

                    // Resolve relative src against the document's BaseURI
                    Url absoluteUrl = new Url(src, document.BaseURI);

                    // Output the absolute URL
                    Console.WriteLine(absoluteUrl.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}