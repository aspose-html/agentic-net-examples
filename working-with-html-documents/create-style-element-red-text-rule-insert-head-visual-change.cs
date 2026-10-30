// Create a style element with a red text rule, insert it into head, and verify visual change.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            string baseUri = "about:blank";

            // Load HTML document from inline content
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Create <style> element with red text rule
            Element style = document.CreateElement("style");
            style.TextContent = "body { color: red; }";

            // Append the style element to <head>
            Element head = (Element)document.GetElementsByTagName("head")[0];
            head.AppendChild(style);

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            // Reload the saved document to verify the style element
            HTMLDocument reloaded = new HTMLDocument(outputPath);
            Element loadedStyle = (Element)reloaded.GetElementsByTagName("style")[0];

            if (loadedStyle != null && loadedStyle.TextContent.Trim() == "body { color: red; }")
            {
                Console.WriteLine("Style applied and verified successfully.");
            }
            else
            {
                Console.WriteLine("Verification failed: style element not found or content mismatch.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}