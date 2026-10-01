// Change text color of all heading tags (h1‑h3) using a single internal CSS rule.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<!DOCTYPE html>" +
                    "<html>" +
                    "<head><title>Sample</title></head>" +
                    "<body>" +
                    "<h1>Hello World</h1>" +
                    "<p>Sample paragraph.</p>" +
                    "</body>" +
                    "</html>");
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a <style> element and add CSS rules
            var style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.TextContent = "body { background-color: #f0f0f0; }";

            // Append the style element to the <head>
            var head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Change the color of the first <h1> element
            var header = (Aspose.Html.HTMLElement)document.GetElementsByTagName("h1").First();
            header.Style.Color = "blue";

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}