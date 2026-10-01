// Detect and extract all inline SVG elements and save them as separate .svg files.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with inline SVGs
            string htmlPath = "sample.html";
            string htmlContent = @"
<!DOCTYPE html>
<html>
<body>
<h1>Sample SVGs</h1>
<svg width='100' height='100' xmlns='http://www.w3.org/2000/svg'>
  <circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' />
</svg>
<p>Some text here.</p>
<svg width='200' height='100' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='100' style='fill:blue;stroke:pink;stroke-width:5;opacity:0.5' />
</svg>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Get all inline SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Prepare output directory
            string outputDir = "output_svgs";
            Directory.CreateDirectory(outputDir);

            // Track processed SVG markup to avoid duplicates
            HashSet<string> seenMarkups = new HashSet<string>();

            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                if (!seenMarkups.Add(markup))
                    continue; // Skip duplicate SVGs

                string fileName = $"{i}.svg";
                string outputPath = Path.Combine(outputDir, fileName);

                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "");
                svgDoc.Save(outputPath);
            }

            Console.WriteLine("SVG extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}