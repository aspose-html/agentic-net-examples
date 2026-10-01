// Retrieve contrast ratio values for specific foreground and background colors and log any failures.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output folders
            string inputFolder = "Input";
            string outputFolder = "Output";

            // Ensure output folder exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Ensure input folder exists
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Create a sample SVG file if none exist
            string[] existingSvg = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvg.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
@"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='red'/>
</svg>");
            }

            // Get SVG files
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
                    options.BackgroundColor = Color.White;
                    options.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }

            // Prepare a sample HTML file
            string htmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath,
@"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body><h1>Hello, Aspose.HTML!</h1></body>
</html>");
            }

            // Convert HTML to BMP image
            string bmpOutputPath = Path.Combine(outputFolder, "sample.bmp");
            Aspose.Html.HTMLDocument htmlDocForBmp = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.ImageSaveOptions bmpOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            bmpOptions.UseAntialiasing = false;
            bmpOptions.HorizontalResolution = 300;
            bmpOptions.VerticalResolution = 300;
            bmpOptions.BackgroundColor = Color.Beige;
            Aspose.Html.Converters.Converter.ConvertHTML(htmlDocForBmp, bmpOptions, bmpOutputPath);

            // Convert HTML to PDF with background color
            string pdfOutputPath = Path.Combine(outputFolder, "sample.pdf");
            Aspose.Html.HTMLDocument htmlDocForPdf = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.HorizontalResolution = 300;
            pdfOptions.VerticalResolution = 300;
            pdfOptions.BackgroundColor = Color.AliceBlue;
            Aspose.Html.Converters.Converter.ConvertHTML(htmlDocForPdf, pdfOptions, pdfOutputPath);

            // Convert EPUB to TIFF image (if EPUB file exists)
            string epubPath = Path.Combine(inputFolder, "sample.epub");
            if (File.Exists(epubPath))
            {
                string epubOutputPath = Path.Combine(outputFolder, "sample_epub.tiff");
                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions epubOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    epubOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
                    epubOptions.UseAntialiasing = true;
                    epubOptions.HorizontalResolution = 300;
                    epubOptions.VerticalResolution = 300;
                    epubOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(800, 600),
                        new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, epubOptions, epubOutputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}