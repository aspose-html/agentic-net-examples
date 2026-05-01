// Use QuerySelector to find the first table element and add a caption describing its purpose.

using System;
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
            var table = document.QuerySelector("table") as HTMLTableElement;
            if (table != null)
            {
                var caption = table.CreateCaption();
                caption.TextContent = "Table caption describing its purpose.";
            }
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}