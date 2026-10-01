// Replace all occurrences of a deprecated attribute (e.g., align) with equivalent CSS styling.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            string htmlContent = "<html><body><p align=\"center\">Centered paragraph.</p><div align=\"right\">Right aligned div.</div></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            var document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("[align]");

            foreach (Aspose.Html.HTMLElement element in elements)
            {
                string align = element.GetAttribute("align");
                element.RemoveAttribute("align");
                element.Style.SetProperty("text-align", align);
            }

            document.Save(outputPath);
            Console.WriteLine("Processing completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}