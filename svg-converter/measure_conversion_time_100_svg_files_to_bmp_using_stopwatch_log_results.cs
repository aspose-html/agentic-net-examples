// Measure conversion time for converting 100 SVG files to BMP using a stopwatch and log results.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Create a minimal sample SVG if none exist
            string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
            if (!File.Exists(sampleSvgPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='red' />
  <circle cx='100' cy='100' r='80' fill='green' />
</svg>";
                File.WriteAllText(sampleSvgPath, svgContent);
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".png");

                using (Aspose.Html.Dom.Svg.SVGDocument document =
                    new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}