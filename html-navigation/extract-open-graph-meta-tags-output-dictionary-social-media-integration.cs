// Extract Open Graph meta tags and output them as a dictionary for social media integration.

using System;
using System.Collections.Generic;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with Open Graph meta tags
            string htmlContent = @"
                <html>
                <head>
                    <meta property=""og:title"" content=""Example Title"" />
                    <meta property=""og:description"" content=""An example description for social media."" />
                    <meta property=""og:image"" content=""https://example.com/image.jpg"" />
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                </head>
                <body>
                    <h1>Hello World</h1>
                </body>
                </html>";

            // Load HTML document from the string (using a dummy base URI)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Collection to hold Open Graph meta tags
                Dictionary<string, string> openGraphTags = new Dictionary<string, string>();

                // Get all <meta> elements
                Aspose.Html.Collections.HTMLCollection metaElements = document.GetElementsByTagName("meta");

                for (int i = 0; i < metaElements.Length; i++)
                {
                    Aspose.Html.HTMLElement meta = (Aspose.Html.HTMLElement)metaElements[i];
                    string property = meta.GetAttribute("property");
                    if (!string.IsNullOrEmpty(property) && property.StartsWith("og:"))
                    {
                        string content = meta.GetAttribute("content") ?? string.Empty;
                        openGraphTags[property] = content;
                    }
                }

                // Output the extracted Open Graph tags
                Console.WriteLine("Extracted Open Graph meta tags:");
                foreach (var kvp in openGraphTags)
                {
                    Console.WriteLine($"{kvp.Key} = {kvp.Value}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}