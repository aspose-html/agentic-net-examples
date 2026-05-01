// Apply internal CSS to all paragraph elements to set a uniform text color across the document.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Paths to the source and destination HTML files
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the existing HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a <style> element to hold internal CSS
            Element style = document.CreateElement("style");

            // Define CSS rule to set a uniform text color for all paragraphs
            style.TextContent = "p { color: #8b0000; }";

            // Retrieve the <head> element of the document
            Element head = document.GetElementsByTagName("head").First();

            // Append the style element to the head section
            head.AppendChild(style);

            // Save the modified document to the specified output path
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}