// Load an HTML file, extract all hyperlink URLs, and write them to a CSV file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "links.csv";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<html><body>" +
                    "<a href=\"https://example.com\">Example</a>" +
                    "<a href=\"https://openai.com\">OpenAI</a>" +
                    "</body></html>");
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("a");

                using (StreamWriter writer = new StreamWriter(outputPath, false))
                {
                    writer.WriteLine("Href,Text");
                    for (int i = 0; i < links.Length; i++)
                    {
                        Aspose.Html.Dom.Element link = links[i] as Aspose.Html.Dom.Element;
                        if (link != null)
                        {
                            string href = link.GetAttribute("href");
                            string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;

                            if (!string.IsNullOrEmpty(href))
                            {
                                string escapedHref = href.Replace("\"", "\"\"");
                                string escapedText = text.Replace("\"", "\"\"");
                                writer.WriteLine($"\"{escapedHref}\",\"{escapedText}\"");
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Hyperlinks have been written to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}