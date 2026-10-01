// Generate a PDF from an SVG source, ensuring vector quality is maintained during conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";

            // Define input and output file paths
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.svg");
            string outputPath = Path.Combine(Path.GetTempPath(), "sample.pdf");

            // Write SVG to a temporary file
            File.WriteAllText(inputPath, svgContent);

            // Configure PDF save options with a custom page size (A4)
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(595, 842) // width, height in points
            );

            // Convert SVG to PDF
            Aspose.Html.Converters.Converter.ConvertSVG(inputPath, pdfOptions, outputPath);

            Console.WriteLine($"PDF successfully saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}