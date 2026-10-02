// Resolve each image src attribute to an absolute URL using Url class and document BaseURI.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with relative image sources
            string htmlContent = @"
                <html>
                    <head><base href='https://example.com/assets/' /></head>
                    <body>
                        <img src='images/pic1.jpg' />
                        <img src='https://cdn.example.com/img/pic2.png' />
                        <img src='' />
                    </body>
                </html>";

            // Load the document with a base URI (about:blank is fine when a <base> tag is present)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            for (int i = 0; i < images.Length; i++)
            {
                Element imageElement = (Element)images[i];
                string src = imageElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Resolve to absolute URL using document's BaseURI
                Url absoluteUrl = new Url(src, document.BaseURI);
                Console.WriteLine($"Image {i + 1}: {absoluteUrl}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}