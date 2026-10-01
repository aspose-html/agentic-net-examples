// Select all anchor elements with href ending in ".pdf" using CSS selector and log URLs.

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Sample HTML content
            string htmlContent = @"
                <html>
                <head><title>Sample</title></head>
                <body>
                    <p id='intro'>Hello, world!</p>
                    <table>
                        <tr><td><a href='https://example.com'>Example</a></td></tr>
                        <tr><td><a href='https://nonexistent.invalid'>Broken</a></td></tr>
                    </table>
                </body>
                </html>";

            // Load document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "http://baseuri/");

            // -----------------------------------------------------------------
            // 1. Extract links inside tables
            // -----------------------------------------------------------------
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
                        Element link = links[i];
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

            // -----------------------------------------------------------------
            // 2. Detect broken links (simple simulation – real network call omitted)
            // -----------------------------------------------------------------
            List<string> brokenLinks = new List<string>();
            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                // Resolve URL against document base URI
                Url resolvedUrl = new Url(href, document.BaseURI);

                // Simulate a request – in a real scenario you would send it:
                // RequestMessage request = new RequestMessage(resolvedUrl);
                // ResponseMessage response = document.Context.Network.Send(request);
                // if ((int)response.StatusCode >= 400)
                // {
                //     brokenLinks.Add(resolvedUrl.ToString());
                // }

                // For demonstration, treat URLs containing "nonexistent" as broken
                if (resolvedUrl.ToString().Contains("nonexistent"))
                {
                    brokenLinks.Add(resolvedUrl.ToString());
                }
            }

            Console.WriteLine("\nBroken links detected:");
            foreach (string url in brokenLinks)
            {
                Console.WriteLine($"  {url}");
            }

            // -----------------------------------------------------------------
            // 3. Modify a paragraph attribute
            // -----------------------------------------------------------------
            HTMLCollection paragraphs = document.GetElementsByTagName("p");
            if (paragraphs.Length > 0)
            {
                HTMLElement paragraph = paragraphs[0] as HTMLElement;
                if (paragraph != null)
                {
                    paragraph.SetAttribute("style", "color:blue;");
                }
            }

            // -----------------------------------------------------------------
            // 4. Save modified HTML to file
            // -----------------------------------------------------------------
            string htmlPath = Path.Combine(outputDir, "modified.html");
            document.Save(htmlPath);
            Console.WriteLine($"\nModified HTML saved to: {htmlPath}");

            // -----------------------------------------------------------------
            // 5. Render HTML to PDF
            // -----------------------------------------------------------------
            string pdfPath = Path.Combine(outputDir, "output.pdf");
            using (PdfDevice device = new PdfDevice(pdfPath))
            {
                document.RenderTo(device);
            }
            Console.WriteLine($"PDF rendered to: {pdfPath}");

            // -----------------------------------------------------------------
            // 6. Query selector example and print inner HTML of each element
            // -----------------------------------------------------------------
            NodeList selectedElements = document.QuerySelectorAll("a");
            Console.WriteLine("\nInnerHTML of selected <a> elements:");
            foreach (HTMLElement element in selectedElements)
            {
                Console.WriteLine($"  {element.InnerHTML}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}