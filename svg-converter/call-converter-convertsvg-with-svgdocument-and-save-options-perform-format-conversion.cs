// Call Converter.ConvertSVG with SVGDocument and save options to perform format conversion.

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

            // Create a simple SVG file
            string svgPath = Path.Combine(dataDir, "sample.svg");
            string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
            File.WriteAllText(svgPath, svgContent);

            // Load SVG document
            var svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Set image save options (convert to JPEG)
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Define output path
            string outputPath = Path.Combine(outputDir, "output.jpg");

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertSVG(svgDoc, options, outputPath);

            Console.WriteLine("SVG conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}