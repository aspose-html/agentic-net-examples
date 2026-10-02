// Measure conversion performance when converting SVG to TIFF with different compression settings across a large dataset.

using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolderNone = "OutputTiff_None";
            string outputFolderLzw = "OutputTiff_Lzw";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolderNone))
                Directory.CreateDirectory(outputFolderNone);
            if (!Directory.Exists(outputFolderLzw))
                Directory.CreateDirectory(outputFolderLzw);

            // Create a minimal sample SVG if none exist
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='red' />
</svg>";
                File.WriteAllText(sampleSvgPath, svgContent);
                existingSvgs = new string[] { sampleSvgPath };
            }

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            long totalTimeNone = 0;
            long totalTimeLzw = 0;

            foreach (string svgPath in svgFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);

                // Conversion with No Compression
                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    options.Compression = Aspose.Html.Rendering.Image.Compression.None;
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    string outputPathNone = Path.Combine(outputFolderNone, fileNameWithoutExt + ".tiff");

                    Stopwatch sw = Stopwatch.StartNew();
                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPathNone);
                    sw.Stop();
                    totalTimeNone += sw.ElapsedMilliseconds;
                }

                // Conversion with LZW Compression (if supported)
                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    // Use LZW compression if the enum value exists; otherwise fallback to None
                    try
                    {
                        options.Compression = (Aspose.Html.Rendering.Image.Compression)Enum.Parse(typeof(Aspose.Html.Rendering.Image.Compression), "Lzw");
                    }
                    catch
                    {
                        options.Compression = Aspose.Html.Rendering.Image.Compression.None;
                    }
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    string outputPathLzw = Path.Combine(outputFolderLzw, fileNameWithoutExt + ".tiff");

                    Stopwatch sw = Stopwatch.StartNew();
                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPathLzw);
                    sw.Stop();
                    totalTimeLzw += sw.ElapsedMilliseconds;
                }
            }

            Console.WriteLine($"Total conversion time with No Compression: {totalTimeNone} ms");
            Console.WriteLine($"Total conversion time with LZW Compression: {totalTimeLzw} ms");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}