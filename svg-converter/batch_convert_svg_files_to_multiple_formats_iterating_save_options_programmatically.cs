// Batch convert a list of SVG files to various formats by iterating over save options programmatically.

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
            string inputFolder = "InputSvgs";
            string outputFolderImages = "OutputImages";
            string outputFolderPdfs = "OutputPdfs";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolderImages))
                Directory.CreateDirectory(outputFolderImages);
            if (!Directory.Exists(outputFolderPdfs))
                Directory.CreateDirectory(outputFolderPdfs);

            // Ensure at least one sample SVG exists
            string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
            if (!File.Exists(sampleSvgPath))
            {
                string sampleSvgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange' stroke='black' stroke-width='2'/>
</svg>";
                File.WriteAllText(sampleSvgPath, sampleSvgContent);
            }

            // -------------------------------------------------
            // 1. Convert SVG files to PNG images
            // -------------------------------------------------
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");
            int total = svgFiles.Length;
            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string outputPath = Path.Combine(outputFolderImages,
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

            // -------------------------------------------------
            // 2. Convert SVG files to PDF documents
            // -------------------------------------------------
            foreach (string svgPath in svgFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string pdfPath = Path.Combine(outputFolderPdfs, fileName + ".pdf");

                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                // Set page size to 800x600 points with 10pt margins
                pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, pdfOptions, pdfPath);
                Console.WriteLine($"PDF created: {Path.GetFileName(pdfPath)}");
            }

            // -------------------------------------------------
            // 3. Convert a hard‑coded SVG string to JPEG image
            // -------------------------------------------------
            string svgCode = @"<svg width='300' height='150' xmlns='http://www.w3.org/2000/svg'>
  <rect width='300' height='150' fill='lightgreen'/>
  <text x='150' y='75' font-size='30' text-anchor='middle' fill='darkgreen'>Hello</text>
</svg>";

            string tempSvgPath = Path.Combine(inputFolder, "temp.svg");
            File.WriteAllText(tempSvgPath, svgCode);

            string jpegOutputPath = Path.Combine(outputFolderImages, "svg_from_string.jpg");
            Aspose.Html.Saving.ImageSaveOptions jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            jpegOptions.BackgroundColor = System.Drawing.Color.White;
            jpegOptions.UseAntialiasing = true;

            Aspose.Html.Converters.Converter.ConvertSVG(tempSvgPath, jpegOptions, jpegOutputPath);
            Console.WriteLine($"JPEG image created from string: {Path.GetFileName(jpegOutputPath)}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}