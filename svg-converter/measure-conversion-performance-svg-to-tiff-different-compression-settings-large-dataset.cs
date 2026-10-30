// Measure conversion performance when converting SVG to TIFF with different compression settings across a large dataset.

using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputTiffs";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            if (svgFiles.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
                    "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>");
                svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            }

            int total = svgFiles.Length;
            Stopwatch swNone = new Stopwatch();
            Stopwatch swDefault = new Stopwatch();

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string baseName = Path.GetFileNameWithoutExtension(svgPath);
                string outputPathNone = Path.Combine(outputFolder, baseName + "_none.tiff");
                string outputPathDefault = Path.Combine(outputFolder, baseName + "_default.tiff");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    // Conversion with Compression.None
                    Aspose.Html.Saving.ImageSaveOptions optionsNone = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    optionsNone.Compression = Aspose.Html.Rendering.Image.Compression.None;
                    optionsNone.HorizontalResolution = 300;
                    optionsNone.VerticalResolution = 300;

                    swNone.Start();
                    Aspose.Html.Converters.Converter.ConvertSVG(document, optionsNone, outputPathNone);
                    swNone.Stop();

                    // Conversion with default compression (no explicit setting)
                    Aspose.Html.Saving.ImageSaveOptions optionsDefault = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    optionsDefault.HorizontalResolution = 300;
                    optionsDefault.VerticalResolution = 300;

                    swDefault.Start();
                    Aspose.Html.Converters.Converter.ConvertSVG(document, optionsDefault, outputPathDefault);
                    swDefault.Stop();
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {baseName}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total time with Compression.None: {swNone.Elapsed}");
            Console.WriteLine($"Total time with default compression: {swDefault.Elapsed}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}