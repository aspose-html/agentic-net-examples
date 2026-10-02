// Apply internal CSS to all paragraph elements to set a uniform text color across the document.

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
            // Sample HTML content with paragraphs
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";

            // Load HTML from string (inline content)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create a <style> element with internal CSS to set paragraph text color
            Aspose.Html.Dom.Element styleElement = document.CreateElement("style");
            styleElement.TextContent = "p { color: blue; }";

            // Append the style element to the <head> section
            Aspose.Html.Dom.Element headElement = document.GetElementsByTagName("head").First();
            headElement.AppendChild(styleElement);

            // Save the modified document to a file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine($"Document saved successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}