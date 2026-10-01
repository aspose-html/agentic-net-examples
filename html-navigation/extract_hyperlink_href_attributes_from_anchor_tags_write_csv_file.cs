// Extract all hyperlink href attributes from anchor tags and write them to a CSV file.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<html><body>" +
                                 "<a href='https://example.com'>Example</a>" +
                                 "<a href='https://test.com'>Test</a>" +
                                 "<a href=''>Empty</a>" +
                                 "</body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("a");
                List<string> hrefs = new List<string>();

                for (int i = 0; i < links.Length; i++)
                {
                    Aspose.Html.Dom.Element link = links[i];
                    string href = link.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href))
                    {
                        hrefs.Add(href);
                    }
                }

                // Write hrefs to CSV
                string csvPath = "links.csv";
                using (StreamWriter writer = new StreamWriter(csvPath))
                {
                    writer.WriteLine("Href");
                    foreach (string href in hrefs)
                    {
                        string escaped = href.Replace("\"", "\"\"");
                        writer.WriteLine($"\"{escaped}\"");
                    }
                }

                Console.WriteLine($"Extracted {hrefs.Count} links to {csvPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}