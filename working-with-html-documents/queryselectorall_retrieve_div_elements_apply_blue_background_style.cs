// Use QuerySelectorAll to retrieve all <div> elements and apply a blue background style.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><head><title>Test</title></head><body><div>Div1</div><div>Div2</div></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("div");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.Style.BackgroundColor = "blue";
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Background color applied and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}