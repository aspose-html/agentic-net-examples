// Use HTMLDocument.CreateElement to create a style element, append to head, and define a text color rule.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";

            // Load the HTML document from the string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create a <style> element and set its CSS content
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253); } p { color: blue; }";

            // Get the <head> element and append the style element
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the modified document to a file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine($"Document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}