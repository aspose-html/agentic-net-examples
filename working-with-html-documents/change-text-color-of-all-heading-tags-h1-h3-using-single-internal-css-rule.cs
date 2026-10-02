// Change text color of all heading tags (h1‑h3) using a single internal CSS rule.

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Heading 1</h1><h2>Heading 2</h2><h3>Heading 3</h3><p>Paragraph.</p></body></html>";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "h1, h2, h3 { color: red; }";

            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}