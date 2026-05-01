// Add a comment node describing style changes before the style element in the head section.

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
            string inputPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(inputPath);
            Element style = document.CreateElement("style");
            style.TextContent = "p { color: #8b0000; }";

            Comment comment = document.CreateComment("Style changes: paragraph text color set to dark red");
            Element head = document.GetElementsByTagName("head").First();

            head.AppendChild(comment);
            head.AppendChild(style);

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}