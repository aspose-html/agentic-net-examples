// Convert an SVG file to PDF while automatically adjusting page size to the widest element using AdjustToWidestPage.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG and output PDF paths
            string inputPath = "sample.svg";
            string outputPath = "output.pdf";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(inputPath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""500"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""500"" height=""200"" fill=""lightblue"" />
  <text x=""250"" y=""100"" font-size=""30"" text-anchor=""middle"" fill=""darkblue"">Sample SVG</text>
</svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            // Load the SVG document
            SVGDocument document = new SVGDocument(inputPath);

            // Configure PDF save options (page size will be adjusted automatically based on content)
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert SVG to PDF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to PDF: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}