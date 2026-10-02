// Batch convert multiple SVG images to GIF format while applying custom ImageSaveOptions for each file.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputGifs";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Ensure at least one SVG file exists
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                string sampleSvgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'>
  <rect width='100' height='100' fill='red' />
</svg>";
                File.WriteAllText(sampleSvgPath, sampleSvgContent);
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(svgPath) + ".gif");

                using (SVGDocument document = new SVGDocument(svgPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
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
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}