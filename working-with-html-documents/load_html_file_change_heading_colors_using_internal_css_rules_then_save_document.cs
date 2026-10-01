// Load an HTML file, change heading colors using internal CSS rules, then save the document.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a <style> element and set its content
            var styleElement = (Aspose.Html.HTMLElement)document.CreateElement("style");
            styleElement.TextContent = "body { background-color: rgb(229, 243, 253); }";

            // Append the style element to the <head>
            var head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
            head.AppendChild(styleElement);

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