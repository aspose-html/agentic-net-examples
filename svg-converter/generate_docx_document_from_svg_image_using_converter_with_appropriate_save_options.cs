// Generate a DOCX document from an SVG image using the Converter with appropriate save options.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgCode = "<svg width=\"200\" height=\"200\" xmlns=\"http://www.w3.org/2000/svg\"><rect width=\"200\" height=\"200\" fill=\"red\"/></svg>";

            // Write SVG to a temporary file (required by the file‑based overload)
            string tempSvgPath = Path.Combine(Path.GetTempPath(), "sample.svg");
            File.WriteAllText(tempSvgPath, svgCode);

            // Prepare output directory and file path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "result.doc");

            // Set DOC save options
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Convert SVG file to DOC
            Aspose.Html.Converters.Converter.ConvertSVG(tempSvgPath, options, outputPath);

            Console.WriteLine($"SVG successfully converted to DOC: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}