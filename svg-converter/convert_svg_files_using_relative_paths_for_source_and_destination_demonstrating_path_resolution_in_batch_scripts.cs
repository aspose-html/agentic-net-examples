// Convert SVG files using relative paths for source and destination, demonstrating path resolution in batch scripts.

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

            // Create a sample SVG file if none exist
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                string sampleSvgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange' stroke='black' stroke-width='2'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='black'>SVG</text>
</svg>";
                File.WriteAllText(sampleSvgPath, sampleSvgContent);
            }

            // Get SVG files
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);

            foreach (string svgPath in svgFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(svgPath);

                // Convert to PDF with custom margin
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                // Set page size (A4) and margins (10 points on each side)
                var pageSize = new Aspose.Html.Drawing.Size(595, 842); // Width x Height in points
                var margin = new Aspose.Html.Drawing.Margin(10, 10, 10, 10);
                pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(pageSize, margin);
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, pdfOptions, pdfPath);

                // Convert to PNG image with resolution and background
                string pngPath = Path.Combine(outputFolder, fileName + ".png");
                using (var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
                {
                    var imgOptions = new Aspose.Html.Saving.ImageSaveOptions();
                    imgOptions.HorizontalResolution = 300;
                    imgOptions.VerticalResolution = 300;
                    imgOptions.BackgroundColor = Color.White;
                    imgOptions.UseAntialiasing = true;
                    Aspose.Html.Converters.Converter.ConvertSVG(document, imgOptions, pngPath);
                }

                Console.WriteLine($"Converted '{Path.GetFileName(svgPath)}' to PDF and PNG.");
            }

            Console.WriteLine("All conversions completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}