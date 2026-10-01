// Apply a background color style to the selected paragraph element.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a <style> element and add CSS rules
            var styleElement = (Aspose.Html.HTMLElement)document.CreateElement("style");
            styleElement.TextContent = "p { font-weight: bold; }";

            // Append the style element to the <head>
            var head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
            head.AppendChild(styleElement);

            // Modify the first <p> element's background color
            var paragraph = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p").First();
            paragraph.Style.BackgroundColor = "yellow";

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document processed successfully. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}