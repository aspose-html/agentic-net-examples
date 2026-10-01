// Use a foreach directive {{#foreach item in collection}} to repeat a table row for each item.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content with a table containing links
            string htmlContent = @"
                <html>
                <body>
                    <table>
                        <tr><td><a href='https://example.com/page1'>Link 1</a></td></tr>
                        <tr><td><a href='https://example.com/page2'>Link 2</a></td></tr>
                    </table>
                    <table>
                        <tr><td><a href='https://example.com/page3'>Link 3</a></td></tr>
                    </table>
                </body>
                </html>";

            // Write the HTML to a temporary file so Aspose.Html can load it
            string tempFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFilePath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFilePath);

            // Collection to hold extracted link information
            List<Dictionary<string, string>> extractedLinks = new List<Dictionary<string, string>>();

            // Get all table elements
            Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
            for (int t = 0; t < tables.Length; t++)
            {
                Aspose.Html.HTMLElement htmlTable = tables[t] as Aspose.Html.HTMLElement;
                if (htmlTable == null)
                    continue;

                // Get all anchor elements within the current table
                Aspose.Html.Collections.HTMLCollection links = htmlTable.GetElementsByTagName("a");
                for (int i = 0; i < links.Length; i++)
                {
                    Aspose.Html.Dom.Element link = links[i] as Aspose.Html.Dom.Element;
                    if (link == null)
                        continue;

                    string href = link.GetAttribute("href");
                    string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;

                    if (!string.IsNullOrEmpty(href))
                    {
                        var item = new Dictionary<string, string>
                        {
                            { "href", href },
                            { "text", text }
                        };
                        extractedLinks.Add(item);
                    }
                }
            }

            // Output the extracted links
            Console.WriteLine("Extracted links:");
            foreach (var dict in extractedLinks)
            {
                Console.WriteLine($"Href: {dict["href"]}, Text: {dict["text"]}");
            }

            // Clean up temporary file
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}