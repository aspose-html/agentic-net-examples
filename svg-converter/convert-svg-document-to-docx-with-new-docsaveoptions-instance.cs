// Convert an SVG document to DOCX by providing a new DocSaveOptions instance.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);

            // Create a minimal SVG file
            string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue' />
  <circle cx='100' cy='100' r='80' fill='orange' />
</svg>";
            string sourcePath = Path.Combine(dataDir, "sample.svg");
            File.WriteAllText(sourcePath, svgContent);

            // Define output path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.docx");

            // Create DocSaveOptions
            DocSaveOptions options = new DocSaveOptions();

            // Convert SVG to DOCX
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to DOCX.");
            Console.WriteLine("Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}