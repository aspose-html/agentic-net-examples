// Remove existing style elements from the head before inserting new CSS rules for text color.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body style=\"background-color: #fff;\">Hello World</body></html>";
            string outputPath = "output.html";

            // Load HTML document from the string literal
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get the <body> element
            var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();

            // Remove existing background-color style
            body.Style.RemoveProperty("background-color");

            // Create a new <style> element
            var style = (Aspose.Html.Dom.Element)document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";

            // Get the <head> element and append the style
            var head = (Aspose.Html.Dom.Element)document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine($"Document saved to: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}