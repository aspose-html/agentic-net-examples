// Use CSS selectors to find all bold text elements and replace their inner HTML with uppercase text.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><p>This is <b>bold</b> and <strong>strong</strong> text.</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("b, strong");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string upperText = element.InnerHTML.ToUpperInvariant();
                element.InnerHTML = upperText;
            }

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
            Console.WriteLine($"Modified HTML saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}