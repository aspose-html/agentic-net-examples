// Load an HTML file, change heading colors using internal CSS rules, then save the document.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

namespace HtmlHeadingColorChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source HTML file
                string inputPath = "input.html";

                // Path where the modified HTML will be saved
                string outputPath = "output.html";

                // Load the existing HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Create a new <style> element
                Element style = document.CreateElement("style");

                // Define internal CSS to change all <h1> colors to darkred
                style.TextContent = "h1 { color: darkred; }";

                // Append the style element to the <head> section
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