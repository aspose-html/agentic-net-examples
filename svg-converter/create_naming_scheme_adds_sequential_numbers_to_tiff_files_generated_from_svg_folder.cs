// Create a naming scheme that adds sequential numbers to TIFF files generated from a folder of SVGs.

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
            string inputFolder = "InputSvg";
            string outputPdfFolder = "OutputPdf";
            string outputImgFolder = "OutputImages";
            string outputTiffFolder = "OutputTiff";

            if (!Directory.Exists(inputFolder)) Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputPdfFolder)) Directory.CreateDirectory(outputPdfFolder);
            if (!Directory.Exists(outputImgFolder)) Directory.CreateDirectory(outputImgFolder);
            if (!Directory.Exists(outputTiffFolder)) Directory.CreateDirectory(outputTiffFolder);

            // Ensure at least one sample SVG exists
            string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
            if (!File.Exists(sampleSvgPath))
            {
                string sampleSvgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightblue""/>
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange""/>
  <text x=""100"" y=""115"" font-size=""30"" text-anchor=""middle"" fill=""white"">SVG</text>
</svg>";
                File.WriteAllText(sampleSvgPath, sampleSvgContent);
            }

            // 1. Convert SVG files to PDF with custom page margins
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            foreach (string svgPath in svgFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = Path.Combine(outputPdfFolder, fileName + ".pdf");

                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                var pageSize = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points
                var pageMargin = new Aspose.Html.Drawing.Margin(10, 10, 10, 10);
                pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(pageSize, pageMargin);

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, pdfOptions, pdfPath);
                Console.WriteLine($"Converted to PDF: {Path.GetFileName(pdfPath)}");
            }

            // 2. Convert SVG files to PNG images with resolution and antialiasing
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputImgFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".png");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    var imgOptions = new Aspose.Html.Saving.ImageSaveOptions();
                    imgOptions.HorizontalResolution = 300;
                    imgOptions.VerticalResolution = 300;
                    imgOptions.BackgroundColor = Color.White;
                    imgOptions.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, imgOptions, outputPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }

            // 3. Convert a specific SVG to TIFF with no compression
            if (svgFiles.Length > 0)
            {
                string svgPath = svgFiles[0];
                string tiffPath = Path.Combine(outputTiffFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".tiff");

                var tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
                tiffOptions.HorizontalResolution = 300;
                tiffOptions.VerticalResolution = 300;
                tiffOptions.BackgroundColor = Color.White;
                tiffOptions.UseAntialiasing = true;

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, tiffOptions, tiffPath);
                Console.WriteLine($"Converted to TIFF: {Path.GetFileName(tiffPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}