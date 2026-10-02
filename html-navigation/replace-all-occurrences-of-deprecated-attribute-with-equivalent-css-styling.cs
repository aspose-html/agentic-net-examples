// Replace all occurrences of a deprecated attribute (e.g., align) with equivalent CSS styling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p align=\"center\">Hello</p><div align=\"right\">World</div></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var elements = document.QuerySelectorAll("[align]");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string alignValue = element.GetAttribute("align");
                element.RemoveAttribute("align");
                element.Style.TextAlign = alignValue;
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