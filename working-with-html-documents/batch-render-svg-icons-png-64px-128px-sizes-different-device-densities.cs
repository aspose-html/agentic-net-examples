// Batch render SVG icons to PNG at 64 px and 128 px sizes for different device densities.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "svg-icons";
            string outputFolder = "png-output";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample SVG if none exist
            if (Directory.GetFiles(inputFolder, "*.svg").Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath, "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><circle cx='50' cy='50' r='40' fill='red' /></svg>");
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string baseName = Path.GetFileNameWithoutExtension(svgPath);

                // 64 px output
                string outputPath64 = Path.Combine(outputFolder, baseName + "_64.png");
                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                    options.HorizontalResolution = 64;
                    options.VerticalResolution = 64;
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.UseAntialiasing = true;
                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath64);
                }

                // 128 px output
                string outputPath128 = Path.Combine(outputFolder, baseName + "_128.png");
                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                    options.HorizontalResolution = 128;
                    options.VerticalResolution = 128;
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.UseAntialiasing = true;
                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath128);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath64)}, {Path.GetFileName(outputPath128)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}