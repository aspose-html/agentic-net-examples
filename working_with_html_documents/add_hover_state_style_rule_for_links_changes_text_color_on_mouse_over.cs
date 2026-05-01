// Add a hover state style rule for links that changes text color when the mouse is over.

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

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a <style> element
            Element style = document.CreateElement("style");

            // Define hover style for links
            style.TextContent = "a:hover { color: red; }";

            // Append the style element to the <head>
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