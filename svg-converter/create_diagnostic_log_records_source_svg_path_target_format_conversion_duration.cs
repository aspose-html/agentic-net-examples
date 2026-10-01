// Create a diagnostic log that records source SVG path, target format, and conversion duration.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvgs";
            string outputFolder = "OutputImages";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Ensure at least one SVG file exists
            string[] existingSvgs = Directory.GetFiles(inputFolder, "*.svg");
            if (existingSvgs.Length == 0)
            {
                string sampleSvgPath = Path.Combine(inputFolder, "sample.svg");
                File.WriteAllText(sampleSvgPath,
@"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='red'/>
  <circle cx='100' cy='100' r='80' fill='green'/>
</svg>");
                existingSvgs = new[] { sampleSvgPath };
            }

            string[] svgFiles = existingSvgs;
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
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.UseAntialiasing = true;

                    Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                }

                int percent = (i + 1) * 100 / total;
                Console.WriteLine($"Converted {i + 1}/{total} ({percent}%) - {Path.GetFileName(outputPath)}");
            }

            // Convert the first SVG to PDF
            if (total > 0)
            {
                string pdfOutputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(svgFiles[0]) + ".pdf");
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertSVG(svgFiles[0], pdfOptions, pdfOutputPath);
                Console.WriteLine($"PDF saved: {pdfOutputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}