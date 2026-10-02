// Batch convert SVG icons to PNG format at 128 px size for mobile application assets.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string inputDir = "SvgIcons";
            string outputDir = "PngAssets";

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create a sample SVG file if none exist (for demonstration)
            if (!Directory.Exists(inputDir))
                Directory.CreateDirectory(inputDir);
            string sampleSvgPath = Path.Combine(inputDir, "sample.svg");
            if (!File.Exists(sampleSvgPath))
            {
                File.WriteAllText(sampleSvgPath,
                    @"<svg xmlns='http://www.w3.org/2000/svg' width='128' height='128'><rect width='128' height='128' fill='red'/></svg>");
            }

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            foreach (string svgPath in svgFiles)
            {
                // Prepare output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);
                string pngPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Configure image save options
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 128;
                options.VerticalResolution = 128;
                options.UseAntialiasing = true;
                options.BackgroundColor = System.Drawing.Color.Transparent;

                // Convert SVG to PNG
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pngPath);
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}