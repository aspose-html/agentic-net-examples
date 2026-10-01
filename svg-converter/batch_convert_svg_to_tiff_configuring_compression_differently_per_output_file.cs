// Batch convert SVG files to TIFF, configuring Compression property differently for each output file.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output folders
            string inputFolder = "InputSvg";
            string outputFolder = "OutputImages";
            string pdfOutputFolder = "OutputPdf";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            if (!Directory.Exists(pdfOutputFolder))
                Directory.CreateDirectory(pdfOutputFolder);

            // Create a sample SVG file if none exist
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
@"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <circle cx='100' cy='100' r='80' fill='green' stroke='black' stroke-width='2'/>
</svg>");
                existingSvgs = new[] { sampleSvgPath };
            }

            // Convert each SVG to PNG (default image format)
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".png");

                using (Aspose.Html.Dom.Svg.SVGDocument document =
                    new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
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

            // Convert first SVG to TIFF with specific options
            if (total > 0)
            {
                string svgPath = svgFiles[0];
                string tiffPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".tiff");

                using (Aspose.Html.Dom.Svg.SVGDocument document =
                    new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions tiffOptions =
                        new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
                    tiffOptions.HorizontalResolution = 300;
                    tiffOptions.VerticalResolution = 300;
                    tiffOptions.BackgroundColor = System.Drawing.Color.White;
                    tiffOptions.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, tiffOptions, tiffPath);
                }

                Console.WriteLine($"TIFF conversion completed: {Path.GetFileName(tiffPath)}");
            }

            // Convert each SVG to PDF
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string pdfPath = Path.Combine(pdfOutputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".pdf");

                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, pdfOptions, pdfPath);

                Console.WriteLine($"PDF conversion completed: {Path.GetFileName(pdfPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}