// Load an HTML file, extract all hyperlink URLs, and write them to a CSV file.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace ExtractLinks
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "input.html";
                string csvPath = "links.csv";

                // Load the HTML document from the specified file
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Collect all hyperlinks
                var links = new List<(string href, string text)>();

                // The Links property contains all <a> elements with an href attribute
                foreach (Element link in document.Links)
                {
                    string href = link.GetAttribute("href");
                    string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;
                    if (!string.IsNullOrEmpty(href))
                    {
                        links.Add((href, text));
                    }
                }

                // Write the extracted links to a CSV file
                using (var writer = new StreamWriter(csvPath))
                {
                    writer.WriteLine("Href,Text");
                    foreach (var item in links)
                    {
                        // Escape double quotes for CSV compliance
                        string escapedHref = $"\"{item.href.Replace("\"", "\"\"")}\"";
                        string escapedText = $"\"{item.text.Replace("\"", "\"\"")}\"";
                        writer.WriteLine($"{escapedHref},{escapedText}");
                    }
                }

                Console.WriteLine($"Extracted {links.Count} links to {csvPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}