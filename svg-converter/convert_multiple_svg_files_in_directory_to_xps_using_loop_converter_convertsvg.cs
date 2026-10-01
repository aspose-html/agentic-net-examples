// Convert multiple SVG files in a directory to XPS using a loop with Converter.ConvertSVG.

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
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a simple SVG file if it does not exist
            string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
            if (!File.Exists(sampleSvgPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'><rect width='200' height='200' fill='red'/></svg>";
                File.WriteAllText(sampleSvgPath, svgContent);
            }

            // -------------------------------------------------
            // Convert SVG to XPS with custom options
            // -------------------------------------------------
            string xpsOutputPath = Path.Combine(outputFolder, "sample.xps");
            var xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
            xpsOptions.HorizontalResolution = 300;
            xpsOptions.VerticalResolution = 300;
            xpsOptions.BackgroundColor = Color.AliceBlue;

            var xpsPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
            xpsOptions.PageSetup.AnyPage = xpsPage;

            Aspose.Html.Converters.Converter.ConvertSVG(sampleSvgPath, xpsOptions, xpsOutputPath);

            // -------------------------------------------------
            // Convert SVG to PDF
            // -------------------------------------------------
            string pdfOutputPath = Path.Combine(outputFolder, "sample.pdf");
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.PageSetup.AnyPage = xpsPage; // reuse the same page definition
            Aspose.Html.Converters.Converter.ConvertSVG(sampleSvgPath, pdfOptions, pdfOutputPath);

            // -------------------------------------------------
            // Convert SVG to PNG image with rendering options
            // -------------------------------------------------
            string pngOutputPath = Path.Combine(outputFolder, "sample.png");
            var imgOptions = new Aspose.Html.Saving.ImageSaveOptions();
            imgOptions.HorizontalResolution = 200;
            imgOptions.VerticalResolution = 200;
            imgOptions.BackgroundColor = Color.White;
            imgOptions.UseAntialiasing = true;
            Aspose.Html.Converters.Converter.ConvertSVG(sampleSvgPath, imgOptions, pngOutputPath);

            // -------------------------------------------------
            // Batch convert all SVG files in the input folder to PDF
            // -------------------------------------------------
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string batchPdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                var batchPdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                var batchPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(20, 20, 20, 20));
                batchPdfOptions.PageSetup.AnyPage = batchPage;

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, batchPdfOptions, batchPdfPath);

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(batchPdfPath)}");
            }

            Console.WriteLine("All conversions completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}