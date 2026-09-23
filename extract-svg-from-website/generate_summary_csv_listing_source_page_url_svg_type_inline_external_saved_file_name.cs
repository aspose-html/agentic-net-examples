// Generate a summary CSV file that lists source page URL, SVG type (inline or external), and saved file name.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML and external SVG files
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            string htmlPath = Path.Combine(outputDir, "sample.html");
            string externalSvgPath = Path.Combine(outputDir, "external.svg");

            string htmlContent = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <h1>Inline SVG</h1>
    <svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'>
        <rect width='100' height='100' style='fill:blue;'/>
    </svg>
    <h1>External SVG</h1>
    <img src='external.svg' alt='External SVG'/>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            string externalSvgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><circle cx='50' cy='50' r='40' fill='red'/></svg>";
            File.WriteAllText(externalSvgPath, externalSvgContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Prepare CSV writer
            string csvPath = Path.Combine(outputDir, "summary.csv");
            using (System.IO.StreamWriter csvWriter = new System.IO.StreamWriter(csvPath, false))
            {
                csvWriter.WriteLine("SourceUrl,SvgType,FileName");

                // Process inline SVG elements
                Aspose.Html.Collections.HTMLCollection inlineSvgs = document.GetElementsByTagName("svg");
                for (int i = 0; i < inlineSvgs.Length; i++)
                {
                    Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)inlineSvgs[i];
                    string svgContent = svgElement.OuterHTML;
                    string fileName = $"inline_{i}.svg";
                    string filePath = Path.Combine(outputDir, fileName);

                    Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgContent, string.Empty);
                    svgDoc.Save(filePath);

                    csvWriter.WriteLine($"{htmlPath},Inline,{fileName}");
                }

                // Process external SVG references (e.g., <img src="...svg">)
                Aspose.Html.Collections.HTMLCollection imgElements = document.GetElementsByTagName("img");
                for (int i = 0; i < imgElements.Length; i++)
                {
                    Aspose.Html.HTMLElement imgElement = (Aspose.Html.HTMLElement)imgElements[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;
                    if (!src.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                        continue;

                    string externalUrl = Path.Combine(outputDir, src);
                    if (!File.Exists(externalUrl))
                        continue;

                    string fileName = $"external_{i}.svg";
                    string destPath = Path.Combine(outputDir, fileName);
                    File.Copy(externalUrl, destPath, true);

                    csvWriter.WriteLine($"{htmlPath},External,{fileName}");
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