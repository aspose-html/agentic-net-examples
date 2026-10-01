// Detect and fix inconsistent indentation in nested lists to ensure proper hierarchical rendering.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><ul><li style=\"margin-left:30px;\">Item 1</li><li>Item 2<ul><li style=\"margin-left:10px;\">Subitem 1</li></ul></li></ul></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, string.Empty);
            Aspose.Html.Collections.NodeList listItems = document.QuerySelectorAll("li");
            foreach (Aspose.Html.HTMLElement li in listItems)
            {
                li.Style.MarginLeft = "0px";
            }
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
            Console.WriteLine("Fixed HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}