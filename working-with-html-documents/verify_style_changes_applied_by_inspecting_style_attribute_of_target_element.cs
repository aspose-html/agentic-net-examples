// Verify that style changes have been applied by inspecting the style attribute of a target element.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><style>p { color: red; }</style></head><body><p>Hello World</p></body></html>";

            // Create an HTML document from the string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Append additional CSS to the existing <style> element
            Aspose.Html.HTMLElement styleElement = (Aspose.Html.HTMLElement)document.QuerySelector("style");
            if (styleElement != null)
            {
                string existingCss = styleElement.InnerHTML;
                styleElement.TextContent = existingCss + " p { background-color: yellow; }";
            }

            // Change background color of all <p> elements
            Aspose.Html.Collections.NodeList pElements = document.QuerySelectorAll("p");
            foreach (Aspose.Html.HTMLElement p in pElements)
            {
                p.Style.BackgroundColor = "lightblue";
            }

            // Save the modified document
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