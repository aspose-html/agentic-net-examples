// Use CSS selectors to find all elements with class "highlight" and change their background color.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p class='highlight'>First</p><div class='highlight'>Second</div><p>No highlight</p></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll(".highlight");

            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.Style.BackgroundColor = "yellow";
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}