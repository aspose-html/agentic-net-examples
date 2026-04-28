// Extract all hyperlink href attributes from anchor tags and write them to a CSV file.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input HTML source (can be a URL or local file path)
            string source = "input.html"; // replace with your HTML file or URL
            // Output CSV file path
            string csvPath = "links.csv";

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(source))
            {
                // Get all anchor elements
                var anchors = document.GetElementsByTagName("a");
                var links = new List<string>();

                for (int i = 0; i < anchors.Length; i++)
                {
                    var element = anchors[i] as Aspose.Html.Dom.Element;
                    if (element != null)
                    {
                        string href = element.GetAttribute("href");
                        if (!string.IsNullOrEmpty(href))
                        {
                            links.Add(href);
                        }
                    }
                }

                // Write links to CSV
                using (var writer = new StreamWriter(csvPath))
                {
                    writer.WriteLine("Href");
                    foreach (var href in links)
                    {
                        // Escape double quotes by doubling them
                        string escaped = href.Replace("\"", "\"\"");
                        writer.WriteLine($"\"{escaped}\"");
                    }
                }

                Console.WriteLine($"Extracted {links.Count} links to '{csvPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}