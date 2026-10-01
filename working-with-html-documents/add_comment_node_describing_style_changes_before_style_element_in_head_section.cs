// Add a comment node describing style changes before the style element in the head section.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file to work with
            string inputPath = "input.html";
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a <style> element and set its CSS content
            var style = document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253); }";

            // Append the style element to the <head>
            var head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Modified HTML saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}