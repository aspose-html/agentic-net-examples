// Batch convert SVG documents to DOCX, setting page size and margins via DocSaveOptions for each conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            string inputSvgPath = Path.Combine(dataDir, "sample.svg");
            string outputPdfPath = Path.Combine(dataDir, "sample.pdf");

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(inputSvgPath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightblue""/>
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange""/>
  <text x=""100"" y=""115"" font-size=""30"" text-anchor=""middle"" fill=""white"">SVG</text>
</svg>";
                File.WriteAllText(inputSvgPath, svgContent);
            }

            // Set PDF save options with page size and margins
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(40, 40, 40, 40); // 40 points margin
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Convert SVG to PDF
            Aspose.Html.Converters.Converter.ConvertSVG(inputSvgPath, options, outputPdfPath);

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"Input SVG: {inputSvgPath}");
            Console.WriteLine($"Output PDF: {outputPdfPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}