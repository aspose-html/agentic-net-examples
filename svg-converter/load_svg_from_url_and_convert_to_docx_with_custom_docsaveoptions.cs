// Load an SVG from a URL and convert it to DOCX with custom DocSaveOptions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgCode = "<svg width=\"200\" height=\"200\" xmlns=\"http://www.w3.org/2000/svg\"><rect width=\"200\" height=\"200\" fill=\"red\"/></svg>";

            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Define temporary SVG file and final PDF output paths
            string tempSvgPath = Path.Combine(outputDir, "sample.svg");
            string outputPath = Path.Combine(outputDir, "sample.pdf");

            // Write SVG content to temporary file
            File.WriteAllText(tempSvgPath, svgCode);

            // Create PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert SVG file to PDF
            Aspose.Html.Converters.Converter.ConvertSVG(tempSvgPath, options, outputPath);

            Console.WriteLine($"SVG successfully converted to PDF at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}