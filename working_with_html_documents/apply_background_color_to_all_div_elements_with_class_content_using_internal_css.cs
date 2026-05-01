// Apply background-color to all div elements with class “content” using internal CSS.

using System;
using System.Linq;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(inputPath);
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "div.content { background-color: #ffcc00; }";
            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head").First();
            head.AppendChild(style);
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}