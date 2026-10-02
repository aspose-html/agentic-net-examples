// Add a comment node describing style changes before the style element in the head section.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "body { background-color: rgb(229, 243, 253) }";

            head.AppendChild(style);

            // Comment node describing style changes
            Aspose.Html.Dom.Comment comment = document.CreateComment("Style changes: background color set to light blue");
            head.InsertBefore(comment, style);

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}