// Measure conversion performance when converting SVG to TIFF with different compression settings across a large dataset.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputTiffs";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            var compressions = new[] { Compression.None };

            foreach (var compression in compressions)
            {
                Console.WriteLine($"Processing with compression: {compression}");
                foreach (var svgPath in svgFiles)
                {
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);
                    string outputPath = Path.Combine(outputFolder, $"{fileNameWithoutExt}_{compression}.tiff");

                    using (SVGDocument document = new SVGDocument(svgPath))
                    {
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                        options.Compression = compression;
                        options.HorizontalResolution = 200;
                        options.VerticalResolution = 200;

                        Stopwatch sw = Stopwatch.StartNew();
                        Converter.ConvertSVG(document, options, outputPath);
                        sw.Stop();

                        Console.WriteLine($"{Path.GetFileName(svgPath)} -> {Path.GetFileName(outputPath)} : {sw.ElapsedMilliseconds} ms");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}