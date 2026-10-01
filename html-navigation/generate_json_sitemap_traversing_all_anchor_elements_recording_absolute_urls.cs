// Generate a JSON sitemap by traversing all anchor elements and recording their absolute URLs.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = @"
                <html>
                    <head><base href='https://example.com/' /></head>
                    <body>
                        <a href='page1.html'>Page 1</a>
                        <a href='https://external.com/page2.html'>External Page</a>
                        <a href='/relative/page3.html'>Relative Page</a>
                    </body>
                </html>";

            // Load HTML document
            using (HTMLDocument document = new HTMLDocument(htmlContent))
            {
                // Get all anchor elements
                HTMLCollection anchors = document.GetElementsByTagName("a");
                List<string> absoluteUrls = new List<string>();

                for (int i = 0; i < anchors.Length; i++)
                {
                    Element link = anchors[i] as Element;
                    if (link == null) continue;

                    string href = link.GetAttribute("href");
                    if (string.IsNullOrEmpty(href)) continue;

                    // Resolve absolute URL
                    Url absoluteUrl = new Url(href, document.BaseURI);
                    absoluteUrls.Add(absoluteUrl.ToString());
                }

                // Serialize to JSON
                string json = JsonSerializer.Serialize(absoluteUrls, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(json);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}