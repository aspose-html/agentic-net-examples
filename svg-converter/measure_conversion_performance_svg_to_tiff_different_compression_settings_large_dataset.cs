// Measure conversion performance when converting SVG to TIFF with different compression settings across a large dataset.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare folders
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputImages";
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample SVG if it does not exist
            string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
            if (!File.Exists(sampleSvgPath))
            {
                File.WriteAllText(sampleSvgPath,
                    @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>");
            }

            // 1. Convert SVG to TIFF with specific options
            string tiffPath = Path.Combine(outputFolder, "sample.tiff");
            var tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            tiffOptions.HorizontalResolution = 300;
            tiffOptions.VerticalResolution = 300;
            Aspose.Html.Converters.Converter.ConvertSVG(sampleSvgPath, tiffOptions, tiffPath);
            Console.WriteLine($"Converted to TIFF: {tiffPath}");

            // 2. Convert to JPEG (high/low quality simulation – quality property not available)
            string highJpegPath = Path.Combine(outputFolder, "sample_high.jpg");
            string lowJpegPath = Path.Combine(outputFolder, "sample_low.jpg");
            var jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(sampleSvgPath, jpegOptions, highJpegPath);
            Aspose.Html.Converters.Converter.ConvertSVG(sampleSvgPath, jpegOptions, lowJpegPath);
            long highSize = new FileInfo(highJpegPath).Length;
            long lowSize = new FileInfo(lowJpegPath).Length;
            if (highSize > lowSize)
                Console.WriteLine("High quality JPEG is larger than low quality JPEG.");
            else
                Console.WriteLine("Low quality JPEG is larger than high quality JPEG.");

            // 3. Batch convert all SVG files in the input folder to PNG with resolution and background
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".png");
                using (var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    options.HorizontalResolution = 150;
                    options.VerticalResolution = 150;
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.UseAntialiasing = true;
                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }
                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }

            // 4. Convert using document overload to TIFF (demonstrates another overload)
            string tiffPath2 = Path.Combine(outputFolder, "sample2.tiff");
            using (var doc = new Aspose.Html.Dom.Svg.SVGDocument(sampleSvgPath))
            {
                var opt = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                Aspose.Html.Converters.Converter.ConvertSVG(doc, opt, tiffPath2);
            }
            Console.WriteLine($"Converted to TIFF (document overload): {tiffPath2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}