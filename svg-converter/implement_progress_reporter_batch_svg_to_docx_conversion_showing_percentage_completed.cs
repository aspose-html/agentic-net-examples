// Implement a progress reporter for batch conversion of SVG files to DOCX, showing percentage completed.

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
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Create a minimal sample SVG file if none exist
            string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
            if (!File.Exists(sampleSvgPath))
            {
                string sampleSvgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
                File.WriteAllText(sampleSvgPath, sampleSvgContent);
            }

            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;

            // 1. Convert each SVG to PNG image
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

            // 2. Convert a single SVG to DOCX
            if (total > 0)
            {
                string documentPath = svgFiles[0]; // use first SVG as example
                string savePath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(documentPath) + ".docx");

                using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(documentPath))
                {
                    Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                    Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(800, 600);
                    Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(20, 20, 20, 20);
                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
                    options.PageSetup.AnyPage = page;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, savePath);
                }

                Console.WriteLine($"SVG converted to DOCX: {Path.GetFileName(savePath)}");
            }

            // 3. Convert all SVG files to PDF
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string pdfPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgPath) + ".pdf");

                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

                // Reuse the same page setup as before
                Aspose.Html.Drawing.Size pdfSize = new Aspose.Html.Drawing.Size(800, 600);
                Aspose.Html.Drawing.Margin pdfMargin = new Aspose.Html.Drawing.Margin(20, 20, 20, 20);
                Aspose.Html.Drawing.Page pdfPage = new Aspose.Html.Drawing.Page(pdfSize, pdfMargin);
                pdfOptions.PageSetup.AnyPage = pdfPage;

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, pdfOptions, pdfPath);

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted to PDF {i + 1}/{total} ({percent}%) - {Path.GetFileName(pdfPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}