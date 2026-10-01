// Batch apply a common internal CSS rule for heading colors across multiple HTML documents.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal HTML file to work with
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a <style> element and set its CSS content
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "p { color: red; font-weight: bold; }";

            // Append the style element to the <head>
            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document saved to: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}