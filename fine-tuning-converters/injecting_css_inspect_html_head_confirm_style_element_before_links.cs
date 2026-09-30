// After injecting CSS, inspect the generated HTML head to confirm the style element appears before existing links.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with existing link elements in the head
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style1.css\"><link rel=\"stylesheet\" href=\"style2.css\"></head><body><p>Hello World</p></body></html>";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Create a style element with CSS
            Aspose.Html.Dom.Element style = (Aspose.Html.Dom.Element)document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";

            // Get the head element
            Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)document.GetElementsByTagName("head").First();

            // Insert the style element before the first existing link element
            Aspose.Html.Dom.Element firstLink = (Aspose.Html.Dom.Element)head.GetElementsByTagName("link").FirstOrDefault();
            if (firstLink != null)
            {
                head.InsertBefore(style, firstLink);
            }
            else
            {
                // If no link elements exist, just append the style
                head.AppendChild(style);
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            // Verify that the style element appears before the first link element
            string savedHtml = File.ReadAllText(outputPath);
            int styleIndex = savedHtml.IndexOf("<style", StringComparison.OrdinalIgnoreCase);
            int firstLinkIndex = savedHtml.IndexOf("<link", StringComparison.OrdinalIgnoreCase);

            if (styleIndex >= 0 && firstLinkIndex >= 0 && styleIndex < firstLinkIndex)
            {
                Console.WriteLine("Success: The style element appears before the first link element.");
            }
            else
            {
                Console.WriteLine("Failure: The style element does not appear before the first link element.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}