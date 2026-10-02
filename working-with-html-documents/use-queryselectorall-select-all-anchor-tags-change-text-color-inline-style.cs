// Use QuerySelectorAll to select all anchor tags and change their text color via inline style.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><a href='https://example.com'>Link1</a> <a href='https://example.org'>Link2</a></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("a");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.SetAttribute("style", "color:red;");
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}