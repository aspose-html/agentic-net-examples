// Apply background-color to all div elements with class “content” using internal CSS.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body><div class=\"content\">Hello</div><div class=\"content\">World</div></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var style = document.CreateElement("style");
            style.TextContent = "div.content { background-color: #ffcc00; }";

            var head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                var htmlElement = document.DocumentElement as Aspose.Html.HTMLElement;
                if (htmlElement != null)
                {
                    htmlElement.InsertBefore(head, document.Body);
                }
            }
            head.AppendChild(style);

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}