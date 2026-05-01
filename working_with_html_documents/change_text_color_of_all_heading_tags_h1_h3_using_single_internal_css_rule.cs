// Change text color of all heading tags (h1‑h3) using a single internal CSS rule.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output HTML file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the existing HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a <style> element
            Element style = document.CreateElement("style");

            // Define a single CSS rule that changes the color of h1‑h3 headings
            style.TextContent = "h1, h2, h3 { color: darkred; }";

            // Locate the <head> element and append the style block
            Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}