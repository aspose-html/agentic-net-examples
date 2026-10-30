// Resolve each image src attribute to an absolute URL using Url class and document BaseURI.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with relative and absolute image sources
            string htmlContent = @"
                <html>
                    <body>
                        <img src='images/pic1.jpg' />
                        <img src='https://cdn.example.com/pic2.png' />
                        <img src='' />
                    </body>
                </html>";

            // Base URI for resolving relative URLs
            string baseUri = "https://example.com/";

            // Load the HTML document with the specified base URI
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            for (int i = 0; i < images.Length; i++)
            {
                Aspose.Html.Dom.Element imageElement = (Aspose.Html.Dom.Element)images[i];
                string src = imageElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Resolve to absolute URL using document's BaseURI
                Aspose.Html.Url absoluteUrl = new Aspose.Html.Url(src, document.BaseURI);
                Console.WriteLine($"Image {i + 1}: {absoluteUrl}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}