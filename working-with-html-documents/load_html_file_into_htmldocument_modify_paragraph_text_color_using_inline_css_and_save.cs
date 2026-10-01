// Load an HTML file into an HTMLDocument, modify paragraph text color using inline CSS, and save.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Hello World</p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)document.GetElementsByTagName("p").First();
            paragraph.Style.Color = "#8b0000";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}