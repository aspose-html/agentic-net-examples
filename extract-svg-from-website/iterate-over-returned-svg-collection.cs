// Iterate over the returned SVG collection.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file with SVG elements
            string htmlPath = "sample.html";
            string htmlContent = "<html><body>" +
                                 "<svg width='100' height='100'></svg>" +
                                 "<svg></svg>" +
                                 "</body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Get all SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Iterate over the SVG collection
            for (int i = 0; i < svgs.Length; i++)
            {
                // Cast to HTMLElement to access properties
                Aspose.Html.HTMLElement element = svgs[i] as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    Console.WriteLine($"SVG {i}: TagName = {element.TagName}");
                }
                else
                {
                    Console.WriteLine($"SVG {i}: Unable to cast element.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}