// Apply a background color style to the selected paragraph element.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";
            string backgroundColor = "#ffcc00";

            HTMLDocument document = new HTMLDocument(inputPath);
            HTMLElement paragraph = (HTMLElement)document.GetElementsByTagName("p").First();
            paragraph.Style.BackgroundColor = backgroundColor;
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}