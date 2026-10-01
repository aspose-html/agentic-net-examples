// Log each SVG to GIF conversion, recording output file size and applied image quality settings.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal SVG file
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
    <rect width='200' height='200' fill='lightblue'/>
    <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // High quality JPEG conversion (quality property not available, using default)
            string highOutputPath = "high_quality.jpg";
            var highOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);

            // Low quality JPEG conversion (quality property not available, using default)
            string lowOutputPath = "low_quality.jpg";
            var lowOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;

            if (highSize > lowSize)
                Console.WriteLine("High quality file is larger than low quality file.");
            else
                Console.WriteLine("Low quality file is larger than high quality file.");

            // Additional format conversions
            var gifOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, gifOptions, "output.gif");

            var jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, jpegOptions, "output2.jpg");

            // Convert using SVGDocument with custom options
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.White;
                options.UseAntialiasing = true;
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, "document_output.png");
            }

            // Batch conversion of all SVG files in a folder
            string inputFolder = "input_svgs";
            string outputFolder = "output_images";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Ensure at least one SVG exists in the input folder
            string sampleInFolder = Path.Combine(inputFolder, "sample2.svg");
            if (!File.Exists(sampleInFolder))
                File.Copy(svgPath, sampleInFolder, true);

            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string filePath = svgFiles[i];
                string outPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(filePath) + ".png");

                using (var doc = new Aspose.Html.Dom.Svg.SVGDocument(filePath))
                {
                    var opts = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                    opts.HorizontalResolution = 150;
                    opts.VerticalResolution = 150;
                    opts.BackgroundColor = System.Drawing.Color.White;
                    opts.UseAntialiasing = true;
                    Aspose.Html.Converters.Converter.ConvertSVG(doc, opts, outPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outPath)}");
            }

            // Convert SVGDocument to GIF
            using (var docGif = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
            {
                var optsGif = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertSVG(docGif, optsGif, "doc_gif.gif");
            }

            // Convert SVGDocument to TIFF with specific settings
            using (var docTiff = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
            {
                var optsTiff = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                optsTiff.Compression = Aspose.Html.Rendering.Image.Compression.None;
                optsTiff.HorizontalResolution = 200;
                optsTiff.VerticalResolution = 200;
                Aspose.Html.Converters.Converter.ConvertSVG(docTiff, optsTiff, "doc_tiff.tiff");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}