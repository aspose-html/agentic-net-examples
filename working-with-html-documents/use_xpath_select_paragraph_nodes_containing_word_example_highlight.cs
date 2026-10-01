// Use XPath to select paragraph nodes containing the word "example" and highlight them.

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
            string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";

            // Create HTML document
            var document = new Aspose.Html.HTMLDocument("", html);

            // Evaluate XPath to get the title node
            Aspose.Html.Dom.XPath.IXPathResult xpathResult = document.Evaluate("//title", document, null, Aspose.Html.Dom.XPath.XPathResultType.Any, null);
            Aspose.Html.Dom.Node node = xpathResult.IterateNext();
            if (node != null)
            {
                Console.WriteLine("Title node name: " + node.NodeName);
            }

            // Query all paragraph elements and print their inner HTML
            var paragraphs = document.QuerySelectorAll("p");
            foreach (Aspose.Html.HTMLElement element in paragraphs)
            {
                Console.WriteLine("Paragraph inner HTML: " + element.InnerHTML);
            }

            // Create a style element and add CSS
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.TextContent = "p { color: blue; }";

            // Append the style element to the head
            var head = document.GetElementsByTagName("head").First() as Aspose.Html.Dom.Element;
            if (head != null)
            {
                head.AppendChild(style);
            }

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}