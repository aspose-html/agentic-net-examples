// Convert an SVG document to DOCX by providing a new DocSaveOptions instance.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input SVG content
            string svgCode = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='green' stroke='black' stroke-width='3'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='white'>SVG</text>
</svg>";

            // Define output directory and file
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "Result.doc");

            // Set DOC save options
            var options = new Aspose.Html.Saving.DocSaveOptions();

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, options, outputPath);

            Console.WriteLine($"SVG has been successfully converted to DOC at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}