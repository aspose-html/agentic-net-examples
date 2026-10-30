// Change text color of all heading tags (h1‑h3) using a single internal CSS rule.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Title</h1><h2>Subtitle</h2><h3>Section</h3></body></html>";
            string outputPath = "output.html";

            // Load HTML from string using two-argument constructor
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Create a <style> element with CSS rule for h1‑h3
            Element style = document.CreateElement("style");
            style.TextContent = "h1, h2, h3 { color: red; }";

            // Append the style element to <head>
            Element head = document.GetElementsByTagName("head")[0];
            head.AppendChild(style);

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