// Replace all em dashes with double hyphens to ensure compatibility with plain‑text viewers.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            // Create a minimal SVG file
            string svgPath = Path.Combine(dataDir, "sample.svg");
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'>
  <circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' />
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Set up save options
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            // Define output path
            string outputPath = Path.Combine(outputDir, "output.docx");

            // Convert SVG to DOCX
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}