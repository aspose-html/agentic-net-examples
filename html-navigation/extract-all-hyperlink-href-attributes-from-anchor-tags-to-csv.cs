// Extract all hyperlink href attributes from anchor tags and write them to a CSV file.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = @"
                <html>
                    <body>
                        <a href=""https://example.com/page1"">Page 1</a>
                        <a href=""https://example.com/page2"">Page 2</a>
                        <a href=""mailto:someone@example.com"">Email</a>
                        <a>No href attribute</a>
                    </body>
                </html>";

            // Load HTML document from string
            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all anchor elements
            Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("a");

            // Prepare CSV output
            string csvPath = "links.csv";
            using (StreamWriter writer = new StreamWriter(csvPath, false))
            {
                // Write CSV header
                writer.WriteLine("Href,Text");

                // Iterate over links and write to CSV
                for (int i = 0; i < links.Length; i++)
                {
                    Aspose.Html.Dom.Element link = links[i];
                    string href = link.GetAttribute("href");
                    string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;

                    if (!string.IsNullOrEmpty(href))
                    {
                        // Escape double quotes in fields
                        string escapedHref = href.Replace("\"", "\"\"");
                        string escapedText = text.Replace("\"", "\"\"");

                        writer.WriteLine($"\"{escapedHref}\",\"{escapedText}\"");
                    }
                }
            }

            Console.WriteLine($"Hyperlink data has been written to '{csvPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}