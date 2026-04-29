// Create a diagnostic log that records source SVG path, target format, and conversion duration.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(svgPath) + ".png");
                using (SVGDocument document = new SVGDocument(svgPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = Color.White;
                    options.UseAntialiasing = true;
                    Stopwatch sw = Stopwatch.StartNew();
                    Converter.ConvertSVG(document, options, outputPath);
                    sw.Stop();
                    Console.WriteLine($"Source: {svgPath}, Target: PNG, Duration: {sw.ElapsedMilliseconds} ms");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}