// Batch convert a folder of SVG files to BMP format using a loop and Converter.ConvertSVG.

using System;
using System.IO;
using System.Drawing;

namespace BatchSvgToBmp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "InputSvgs";
                string outputFolder = "OutputBmps";

                if (!Directory.Exists(inputFolder))
                {
                    Directory.CreateDirectory(inputFolder);
                    string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                    File.WriteAllText(sampleSvgPath, "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>");
                }

                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
                int total = svgFiles.Length;

                for (int i = 0; i < total; i++)
                {
                    string svgPath = svgFiles[i];
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(svgPath) + ".bmp");

                    using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                        options.HorizontalResolution = 96;
                        options.VerticalResolution = 96;
                        options.BackgroundColor = System.Drawing.Color.White;
                        options.UseAntialiasing = true;

                        Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                    }

                    int percent = (i + 1) * 100 / total;
                    Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
                }

                Console.WriteLine("Batch conversion completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}