// Extract the canonical link element href value for SEO analysis from the document.

using System;
using System.Collections.Generic;
using System.IO;
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
            // Prepare a minimal HTML file
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <script src='script.js'></script>
</head>
<body>
    <table>
        <tr><td><a href='https://example.com/valid'>Valid Link</a></td></tr>
        <tr><td><a href='https://example.com/invalid'>Invalid Link</a></td></tr>
    </table>
    <img src='image.png' />
    <a href='https://example.com/valid'>Another Valid Link</a>
</body>
</html>";
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            // Load the document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // 1. Extract links from tables
            HTMLCollection tables = document.GetElementsByTagName("table");
            var tableLinks = new List<Dictionary<string, string>>();
            for (int t = 0; t < tables.Length; t++)
            {
                HTMLElement htmlTable = tables[t] as HTMLElement;
                if (htmlTable != null)
                {
                    HTMLCollection links = htmlTable.GetElementsByTagName("a");
                    for (int i = 0; i < links.Length; i++)
                    {
                        Element link = links[i] as Element;
                        string href = link.GetAttribute("href");
                        string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;
                        if (!string.IsNullOrEmpty(href))
                        {
                            var item = new Dictionary<string, string>
                            {
                                { "href", href },
                                { "text", text }
                            };
                            tableLinks.Add(item);
                        }
                    }
                }
            }

            Console.WriteLine("Links found inside tables:");
            foreach (var dict in tableLinks)
            {
                Console.WriteLine($"  href: {dict["href"]}, text: {dict["text"]}");
            }

            // 2. Find broken links in the whole document
            List<string> brokenLinks = new List<string>();
            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                Url resolvedUrl = new Url(href, document.BaseURI);
                RequestMessage request = new RequestMessage(resolvedUrl);
                ResponseMessage response = document.Context.Network.Send(request);
                if ((int)response.StatusCode >= 400)
                {
                    brokenLinks.Add(resolvedUrl.ToString());
                }
            }

            Console.WriteLine("\nBroken links:");
            foreach (string bl in brokenLinks)
            {
                Console.WriteLine($"  {bl}");
            }

            // 3. List script src attributes
            HTMLCollection scriptElements = document.GetElementsByTagName("script");
            Console.WriteLine("\nScript sources:");
            for (int i = 0; i < scriptElements.Length; i++)
            {
                Element scriptElement = scriptElements[i] as Element;
                string src = scriptElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Console.WriteLine($"  {src}");
                }
            }

            // 4. List image sources
            HTMLCollection images = document.GetElementsByTagName("img");
            Console.WriteLine("\nImage sources:");
            for (int i = 0; i < images.Length; i++)
            {
                Element imageElement = images[i] as Element;
                string src = imageElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Console.WriteLine($"  {src}");
                }
            }

            // 5. Query selector example
            var elements = document.QuerySelectorAll("a");
            Console.WriteLine("\nAll anchor elements via QuerySelectorAll:");
            foreach (HTMLElement element in elements)
            {
                Console.WriteLine($"  href: {element.GetAttribute("href")}, text: {element.TextContent?.Trim()}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}