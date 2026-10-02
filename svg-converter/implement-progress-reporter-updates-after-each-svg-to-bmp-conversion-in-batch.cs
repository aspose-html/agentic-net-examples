// Implement a progress reporter that updates after each SVG file is converted to BMP in a batch operation.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "SvgInput";
            string outputFolder = "BmpOutput";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Create a sample SVG file if none exist
            string[] existingSvgFiles = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvgFiles.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'>
  <rect width='100' height='100' fill='red' />
</svg>";
                File.WriteAllText(sampleSvgPath, svgContent);
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(svgPath) + ".bmp");

                using (SVGDocument document = new SVGDocument(svgPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions();
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;
                    options.BackgroundColor = Color.White;
                    options.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}