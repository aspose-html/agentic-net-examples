// Load an HTML file, replace all <br> tags with newline characters, and save the cleaned file.

using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Example 1: Load HTML from a string, modify meta tag, set body background, save.
            string htmlContent = "<!DOCTYPE html><html><head><meta charset='utf-8'></head><body><p>Hello World</p></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, ""))
            {
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("charset") == "utf-8")
                    {
                        meta.SetAttribute("charset", "utf-16");
                    }
                }

                var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
                body.Style.BackgroundColor = "AliceBlue";

                string outputPath1 = "output_from_string.html";
                document.Save(outputPath1);
                Console.WriteLine($"Saved: {outputPath1}");
            }

            // Example 2: Load HTML from a file, modify a paragraph attribute, save.
            string sampleFilePath = "sample.html";
            File.WriteAllText(sampleFilePath, "<!DOCTYPE html><html><head></head><body><p>Sample paragraph</p></body></html>");
            using (var document = new Aspose.Html.HTMLDocument(sampleFilePath))
            {
                var paragraph = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p").First();
                paragraph.SetAttribute("style", "color:red;");

                string outputPath2 = "sample_modified.html";
                document.Save(outputPath2);
                Console.WriteLine($"Saved: {outputPath2}");
            }

            // Example 3: Create document from a simple HTML string, modify a table attribute, save.
            string tableHtml = "<!DOCTYPE html><html><head></head><body><table><tr><td>Cell</td></tr></table></body></html>";
            using (var document = new Aspose.Html.HTMLDocument(tableHtml))
            {
                Aspose.Html.Dom.Element table = document.QuerySelector("table");
                if (table != null)
                {
                    table.SetAttribute("border", "1");
                }

                string outputPath3 = "table_modified.html";
                document.Save(outputPath3);
                Console.WriteLine($"Saved: {outputPath3}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}