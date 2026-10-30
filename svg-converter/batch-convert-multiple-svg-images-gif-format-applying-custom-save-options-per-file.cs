// Batch convert multiple SVG images to GIF format while applying custom ImageSaveOptions for each file.

using System;
using System.IO;
using System.Drawing;

namespace BatchSvgToGif
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "InputSvgs";
                string outputFolder = "OutputGifs";

                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
                int total = svgFiles.Length;

                for (int i = 0; i < total; i++)
                {
                    string svgPath = svgFiles[i];
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(svgPath) + ".gif");

                    using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
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
}