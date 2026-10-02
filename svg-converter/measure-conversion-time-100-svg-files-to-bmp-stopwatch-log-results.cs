// Measure conversion time for converting 100 SVG files to BMP using a stopwatch and log results.

using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputBmps";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Ensure there are 100 SVG files
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.svg");
            for (int i = existingFiles.Length; i < 100; i++)
            {
                string samplePath = Path.Combine(inputFolder, $"sample{i + 1}.svg");
                File.WriteAllText(samplePath, "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>");
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(svgPath) + ".bmp");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }

            stopwatch.Stop();
            Console.WriteLine($"Total conversion time for {total} files: {stopwatch.Elapsed}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}