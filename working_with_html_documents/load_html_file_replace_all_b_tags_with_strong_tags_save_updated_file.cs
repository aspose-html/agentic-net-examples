// Load an HTML file, replace all <b> tags with <strong> tags, and save the updated file.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output HTML file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Replace all <b> tags with <strong> tags
            var boldElements = document.GetElementsByTagName("b").ToList();
            foreach (var b in boldElements)
            {
                // Preserve inner HTML and wrap it with <strong>
                b.OuterHTML = $"<strong>{b.InnerHTML}</strong>";
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}