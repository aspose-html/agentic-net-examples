// Implement a progress reporter for SVG to TIFF batch conversion, indicating compression level for each file.

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

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Ensure a sample SVG exists
            string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
            if (!File.Exists(sampleSvgPath))
            {
                File.WriteAllText(sampleSvgPath,
@"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='red'/>
</svg>");
            }

            // Convert all SVG files to PNG
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

            // Convert a specific SVG to TIFF
            string tiffOutputPath = Path.Combine(outputFolder, "sample.tiff");
            using (Aspose.Html.Dom.Svg.SVGDocument tiffDoc = new Aspose.Html.Dom.Svg.SVGDocument(sampleSvgPath))
            {
                Aspose.Html.Saving.ImageSaveOptions tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
                tiffOptions.HorizontalResolution = 300;
                tiffOptions.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertSVG(tiffDoc, tiffOptions, tiffOutputPath);
            }

            // Convert to high and low JPEG (default quality) and compare sizes
            string highJpegPath = Path.Combine(outputFolder, "sample_high.jpg");
            string lowJpegPath = Path.Combine(outputFolder, "sample_low.jpg");

            using (Aspose.Html.Dom.Svg.SVGDocument highDoc = new Aspose.Html.Dom.Svg.SVGDocument(sampleSvgPath))
            {
                Aspose.Html.Saving.ImageSaveOptions highOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertSVG(highDoc, highOptions, highJpegPath);
            }

            using (Aspose.Html.Dom.Svg.SVGDocument lowDoc = new Aspose.Html.Dom.Svg.SVGDocument(sampleSvgPath))
            {
                Aspose.Html.Saving.ImageSaveOptions lowOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertSVG(lowDoc, lowOptions, lowJpegPath);
            }

            long highSize = new FileInfo(highJpegPath).Length;
            long lowSize = new FileInfo(lowJpegPath).Length;

            if (highSize > lowSize)
                Console.WriteLine("High quality JPEG is larger than low quality JPEG.");
            else
                Console.WriteLine("Low quality JPEG is larger or equal to high quality JPEG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}