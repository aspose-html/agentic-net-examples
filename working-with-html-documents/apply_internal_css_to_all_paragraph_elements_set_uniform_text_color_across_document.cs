// Apply internal CSS to all paragraph elements to set a uniform text color across the document.

using System;
using System.IO;
using System.Linq;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal input file
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a <style> element and set its CSS content
            var style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.TextContent = "p { color: red; }";

            // Get the <head> element and append the style element
            var head = document.GetElementsByTagName("head").First() as Aspose.Html.HTMLElement;
            head?.AppendChild(style);

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