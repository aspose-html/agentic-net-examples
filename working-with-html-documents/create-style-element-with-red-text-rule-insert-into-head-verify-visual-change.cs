// Create a style element with a red text rule, insert it into head, and verify visual change.

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
            // Prepare sample HTML content
            string htmlContent = "<html><head></head><body><p>Hello World</p></body></html>";

            // Load HTML document from inline content
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Create a <style> element with red text rule
            Element style = document.CreateElement("style");
            style.TextContent = "p { color: red; }";

            // Get the <head> element and append the style
            Element head = (Element)Enumerable.First(
                Enumerable.Cast<Element>(document.GetElementsByTagName("head"))
            );
            head.AppendChild(style);

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
            Console.WriteLine("HTML saved to: " + outputPath);

            // Verify that the style element was saved
            HTMLDocument loadedDoc = new HTMLDocument(outputPath);
            bool hasRedStyle = false;
            foreach (Element el in loadedDoc.GetElementsByTagName("style"))
            {
                if (el.TextContent != null && el.TextContent.Contains("color: red"))
                {
                    hasRedStyle = true;
                    break;
                }
            }

            Console.WriteLine(hasRedStyle ? "Style applied successfully." : "Style not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}