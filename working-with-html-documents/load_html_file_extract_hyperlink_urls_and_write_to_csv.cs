// Load an HTML file, extract all hyperlink URLs, and write them to a CSV file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file with a table containing links
            string htmlContent = @"
                <html>
                <body>
                    <table>
                        <tr><td><a href='https://example.com/page1'>Link 1</a></td></tr>
                        <tr><td><a href='https://example.com/page2'>Link 2</a></td></tr>
                        <tr><td>No link here</td></tr>
                    </table>
                </body>
                </html>";
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all tables in the document
            Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");

            var results = new List<Dictionary<string, string>>();

            for (int t = 0; t < tables.Length; t++)
            {
                Aspose.Html.HTMLElement htmlTable = tables[t] as Aspose.Html.HTMLElement;
                if (htmlTable != null)
                {
                    // Find all links inside the current table
                    Aspose.Html.Collections.HTMLCollection links = htmlTable.GetElementsByTagName("a");
                    for (int i = 0; i < links.Length; i++)
                    {
                        Aspose.Html.Dom.Element link = links[i];
                        string href = link.GetAttribute("href");
                        string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;

                        if (!string.IsNullOrEmpty(href))
                        {
                            var item = new Dictionary<string, string>
                            {
                                { "href", href },
                                { "text", text }
                            };
                            results.Add(item);
                        }
                    }
                }
            }

            // Output the extracted links
            Console.WriteLine("Extracted links from tables:");
            foreach (var dict in results)
            {
                Console.WriteLine($"Href: {dict["href"]}, Text: {dict["text"]}");
            }

            // Clean up the temporary file
            if (File.Exists(inputPath))
            {
                File.Delete(inputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}