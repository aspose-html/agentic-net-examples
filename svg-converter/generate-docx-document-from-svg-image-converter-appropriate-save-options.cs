// Generate a DOCX document from an SVG image using the Converter with appropriate save options.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories
            string dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataDir);
            string outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");
            Directory.CreateDirectory(outputDir);

            // Create a sample SVG file
            string sourcePath = Path.Combine(dataDir, "sample.svg");
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            File.WriteAllText(sourcePath, svgContent);

            // Set DOCX save options
            DocSaveOptions options = new DocSaveOptions();

            // Define output DOCX path
            string outputPath = Path.Combine(outputDir, "result.docx");

            // Convert SVG to DOCX
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}