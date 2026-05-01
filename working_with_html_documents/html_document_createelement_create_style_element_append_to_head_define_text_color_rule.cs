// Use HTMLDocument.CreateElement to create a style element, append to head, and define a text color rule.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Paths to the source and destination HTML files
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Load the existing HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Create a <style> element
                Element style = document.CreateElement("style");

                // Define a CSS rule that sets the text color
                style.TextContent = "p { color: #8b0000; }";

                // Retrieve the <head> element and append the style element
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
}