// Apply internal CSS to all paragraph elements to set a uniform text color across the document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Sample paragraph.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "p { color: #FF0000; }";

            Aspose.Html.Dom.Element head = document.GetElementsByTagName("head")[0];
            head.AppendChild(style);

            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"HTML saved to {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}