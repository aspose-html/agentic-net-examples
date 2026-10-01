// Convert SVG files located in nested subfolders to TIFF, preserving directory structure in output locations.

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

            // Ensure input folder exists and contains at least one SVG file
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Create a minimal sample SVG file if none exist
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
@"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange' stroke='black' stroke-width='2'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='black'>SVG</text>
</svg>");
                existingSvgs = new[] { sampleSvgPath };
            }

            // Get all SVG files
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            int total = svgFiles.Length;

            for (int i = 0; i < total; i++)
            {
                string svgPath = svgFiles[i];
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);

                // Convert to PDF with custom page setup
                string pdfPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(595, 842), // A4 size in points
                    new Aspose.Html.Drawing.Margin(20, 20, 20, 20));
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, pdfOptions, pdfPath);

                // Convert to TIFF using ImageSaveOptions
                string tiffPath = Path.Combine(outputFolder, fileNameWithoutExt + ".tiff");
                var imageOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                imageOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
                imageOptions.HorizontalResolution = 300;
                imageOptions.VerticalResolution = 300;
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, imageOptions, tiffPath);

                // Convert using SVGDocument object (demonstrates DOM usage)
                string tiffFromDocPath = Path.Combine(outputFolder, fileNameWithoutExt + "_doc.tiff");
                using (var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    var docImageOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    docImageOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
                    docImageOptions.HorizontalResolution = 300;
                    docImageOptions.VerticalResolution = 300;
                    Aspose.Html.Converters.Converter.ConvertSVG(document, docImageOptions, tiffFromDocPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(pdfPath)}");
            }

            Console.WriteLine("All conversions completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}