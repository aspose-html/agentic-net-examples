// Apply a background color style to the selected paragraph element.

using System;
using System.Linq;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>Hello World</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var paragraph = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p").First();
            paragraph.Style.BackgroundColor = "lightblue";

            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}