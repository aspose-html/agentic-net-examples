// Insert a horizontal rule before each code block to visually separate code from surrounding text.

//--------------------------------------------------
using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            // Load HTML from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create style element
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "h1 { color: red; }";

            // Append style to head
            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            // Save document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"HTML document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}