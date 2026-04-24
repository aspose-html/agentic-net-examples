// Generate a summary CSV file that lists source page URL, SVG type (inline or external), and saved file name.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Source HTML page URL
            string sourceUrl = "https://example.com/page.html";

            // Load the HTML document from the URL
            HTMLDocument document = new HTMLDocument(sourceUrl);

            // Get all inline <svg> elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Create CSV file and write header
            using (StreamWriter csvWriter = new StreamWriter("svg_summary.csv", false))
            {
                csvWriter.WriteLine("SourceUrl,SVGType,FileName");

                // Iterate over each SVG element
                for (int i = 0; i < svgs.Length; i++)
                {
                    // Cast to HTMLElement and extract outer HTML
                    HTMLElement svgElement = (HTMLElement)svgs[i];
                    string svgContent = svgElement.OuterHTML;

                    // Generate a file name for the SVG
                    string fileName = $"svg_{i}.svg";

                    // Create an SVGDocument from the inline content
                    SVGDocument svgDoc = new SVGDocument(svgContent, sourceUrl);

                    // Save the SVG to a file
                    svgDoc.Save(fileName);

                    // Write CSV row with source URL, type, and file name
                    csvWriter.WriteLine($"{sourceUrl},inline,{fileName}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}