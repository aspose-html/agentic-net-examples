// Add a hover state style rule for links that changes text color when the mouse is over.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file
            string inputPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a <style> element and add CSS
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "p { color: red; }";

            // Append the style to <head>
            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}