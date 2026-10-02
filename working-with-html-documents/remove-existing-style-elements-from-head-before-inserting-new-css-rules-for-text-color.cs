// Remove existing style elements from the head before inserting new CSS rules for text color.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with an existing <style> element
            string htmlContent = "<html><head><style>p {font-size:12px;}</style></head><body><p>Hello World</p></body></html>";

            // Load the HTML document from the string (base URI is required)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Get the <head> element
            Element head = (Element)document.GetElementsByTagName("head").First();

            // Remove all existing <style> elements from the head
            var existingStyles = head.GetElementsByTagName("style").Cast<Element>().ToList();
            foreach (var styleElement in existingStyles)
            {
                head.RemoveChild(styleElement);
            }

            // Create a new <style> element with the desired CSS rule
            Element newStyle = (Element)document.CreateElement("style");
            newStyle.TextContent = "body { color: blue; }";

            // Append the new style element to the head
            head.AppendChild(newStyle);

            // Save the modified document to a file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            // Clean up
            document.Dispose();

            Console.WriteLine($"Document saved successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}