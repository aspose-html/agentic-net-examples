// Load an HTML file, change heading colors using internal CSS rules, then save the document.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Title</h1><h2>Subtitle</h2><p>Paragraph.</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Create internal CSS to change heading colors
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "h1 { color: red; } h2 { color: blue; }";

            // Append the style element to the head
            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}