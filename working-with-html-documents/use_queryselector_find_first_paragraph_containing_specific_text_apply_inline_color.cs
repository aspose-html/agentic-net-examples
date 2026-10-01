// Use QuerySelector to find the first paragraph containing specific text and apply inline color.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>First paragraph.</p><p>Target paragraph with specific text.</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Find the first <p> element using a CSS selector
            Aspose.Html.Dom.Element element = document.QuerySelector("p");

            if (element != null)
            {
                // Cast to HTMLElement to access InnerHTML
                Aspose.Html.HTMLElement paragraph = element as Aspose.Html.HTMLElement;
                if (paragraph != null && paragraph.InnerHTML.Contains("specific text"))
                {
                    // Apply inline color style
                    paragraph.SetAttribute("style", "color:#8b0000;");
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}