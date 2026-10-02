// Generate a summary CSV file that lists source page URL, SVG type (inline or external), and saved file name.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with an inline SVG
            string htmlContent = "<html><body><svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='green' fill='yellow'/></svg></body></html>";
            string htmlFilePath = "sample.html";
            File.WriteAllText(htmlFilePath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath, "about:blank");

            // Get all SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Prepare CSV summary file
            string csvPath = "summary.csv";
            using (StreamWriter csvWriter = new StreamWriter(csvPath, false))
            {
                // Write CSV header
                csvWriter.WriteLine("SourcePageUrl,SVGType,FileName");

                string sourceUrl = Path.GetFullPath(htmlFilePath);

                for (int i = 0; i < svgs.Length; i++)
                {
                    Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                    string svgContent = svgElement.OuterHTML;
                    string fileName = $"svg_{i}.svg";

                    // Save SVG to file
                    Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgContent, "about:blank");
                    svgDoc.Save(fileName);

                    // Determine SVG type (inline in this example)
                    string svgType = "inline";

                    // Write CSV line
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