// Extract all hyperlink href attributes from anchor tags and write them to a CSV file.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body>" +
                                 "<a href=\"https://example.com\">Example</a>" +
                                 "<a href=\"/relative/path\">Relative</a>" +
                                 "<a href=\"mailto:test@example.com\">Email</a>" +
                                 "</body></html>";

            // Load HTML document from string
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Get all anchor elements
                HTMLCollection anchors = document.GetElementsByTagName("a");

                // Output CSV file path
                string outputPath = "links.csv";

                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
                {
                    // Write CSV header
                    writer.WriteLine("Href");

                    // Iterate over anchors and write href values
                    for (int i = 0; i < anchors.Length; i++)
                    {
                        Element element = anchors[i] as Element;
                        if (element != null)
                        {
                            string href = element.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href))
                            {
                                // Escape double quotes in CSV
                                string escapedHref = href.Replace("\"", "\"\"");
                                writer.WriteLine($"\"{escapedHref}\"");
                            }
                        }
                    }
                }

                Console.WriteLine($"Extracted {anchors.Length} hyperlink(s) to \"{outputPath}\".");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}