// Add language identifiers to fenced code blocks to enable proper syntax highlighting in rendered output.

using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input HTML file
            string inputPath = "sample.html";
            string htmlContent = "<html><body><p>Hello World</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the first paragraph element
            Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)System.Linq.Enumerable.First(document.GetElementsByTagName("p"));

            // Change paragraph text color
            paragraph.Style.Color = "red";

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}