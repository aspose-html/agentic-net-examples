// Implement batch conversion of a folder of SVG files to JPEG with uniform quality.

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
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a minimal SVG file if it does not exist
            string svgPath = Path.Combine(inputFolder, "sample.svg");
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='green' />
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // High‑quality conversion (default settings)
            string highOutputPath = Path.Combine(outputFolder, "high.jpg");
            var highOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);

            // Low‑quality conversion (lower resolution)
            string lowOutputPath = Path.Combine(outputFolder, "low.jpg");
            var lowOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            lowOptions.HorizontalResolution = 72;
            lowOptions.VerticalResolution = 72;
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;

            if (highSize > lowSize)
                Console.WriteLine("High quality image is larger than low quality image.");
            else
                Console.WriteLine("Low quality image is larger or equal to high quality image.");

            // Batch conversion of all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string fileSvgPath = svgFiles[i];
                string outPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(fileSvgPath) + ".jpg");

                using (var document = new Aspose.Html.Dom.Svg.SVGDocument(fileSvgPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.UseAntialiasing = true;
                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outPath)}");
            }

            // Convert any HTML files in the input folder to JPEG
            string htmlOutputFolder = Path.Combine(outputFolder, "HtmlToJpeg");
            Directory.CreateDirectory(htmlOutputFolder);
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (var document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outPath = Path.Combine(htmlOutputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outPath);
                }
            }

            // Convert SVG files to PDF
            string pdfOutputFolder = Path.Combine(outputFolder, "Pdf");
            Directory.CreateDirectory(pdfOutputFolder);
            foreach (string fileSvgPath in svgFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(fileSvgPath);
                string pdfPath = Path.Combine(pdfOutputFolder, fileName + ".pdf");
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    pdfOptions.PageSetup.AnyPage.Size,
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
                Aspose.Html.Converters.Converter.ConvertSVG(fileSvgPath, pdfOptions, pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}