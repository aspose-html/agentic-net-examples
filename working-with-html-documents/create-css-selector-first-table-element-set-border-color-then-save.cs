// Create a CSS selector for the first table element and set its border-color, then save.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><table><tr><td>Data</td></tr></table></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Dom.Element tableElement = document.QuerySelector("table");
            if (tableElement != null)
            {
                tableElement.SetAttribute("border-color", "red");
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}