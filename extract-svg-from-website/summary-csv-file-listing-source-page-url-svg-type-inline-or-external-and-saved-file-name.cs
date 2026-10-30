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
            // Source page URL
            string sourceUrl = "https://example.com";

            // Load the HTML document from the URL
            HTMLDocument document = new HTMLDocument(sourceUrl);

            // Get all <svg> elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Prepare CSV summary file
            using (StreamWriter csvWriter = new StreamWriter("summary.csv", false))
            {
                csvWriter.WriteLine("SourceUrl,SVGType,FileName");

                for (int i = 0; i < svgs.Length; i++)
                {
                    // Cast to HTMLElement
                    HTMLElement svgElement = (HTMLElement)svgs[i];

                    // Get the outer HTML of the SVG
                    string svgContent = svgElement.OuterHTML;

                    // Determine SVG type (inline in this case)
                    string svgType = "inline";

                    // Generate file name
                    string fileName = $"svg_{i}.svg";

                    // Create SVG document from the content
                    SVGDocument svgDoc = new SVGDocument(svgContent, "about:blank");

                    // Save the SVG to a file
                    svgDoc.Save(fileName);

                    // Write entry to CSV
                    csvWriter.WriteLine($"{sourceUrl},{svgType},{fileName}");
                }
            }

            Console.WriteLine("SVG extraction and CSV summary completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}