// Implement a progress reporter for SVG to GIF batch conversion, displaying current file name and index.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputImages";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Create a sample SVG if none exist
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
@"<svg width='100' height='100' xmlns='http://www.w3.org/2000/svg'>
  <circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' />
</svg>");
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".png");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
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

            // Additional example: convert the first SVG to GIF
            if (total > 0)
            {
                string firstSvg = svgFiles[0];
                string gifOutput = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(firstSvg) + ".gif");

                Aspose.Html.Saving.ImageSaveOptions gifOptions = new Aspose.Html.Saving.ImageSaveOptions(
                    Aspose.Html.Rendering.Image.ImageFormat.Gif);
                gifOptions.BackgroundColor = System.Drawing.Color.White;
                gifOptions.UseAntialiasing = true;

                Aspose.Html.Converters.Converter.ConvertSVG(firstSvg, gifOptions, gifOutput);
                Console.WriteLine($"Additional conversion to GIF: {Path.GetFileName(gifOutput)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}