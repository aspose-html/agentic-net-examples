// Load an HTML file with LoadOptions that ignore script elements, then apply background color changes.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            var config = new Configuration();
            config.Security |= Sandbox.Scripts;

            string inputPath = "input.html";
            string outputPath = "output.html";

            var document = new HTMLDocument(inputPath, config);
            var body = (HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.BackgroundColor = "#FFCC00";

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}