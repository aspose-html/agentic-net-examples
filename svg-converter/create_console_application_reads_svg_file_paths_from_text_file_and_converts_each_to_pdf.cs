// Create a console application that reads SVG file paths from a text file and converts each to PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string baseUri = "";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Set PDF save options with page size
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));

            // Convert SVG string to PDF file
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, pdfOptions, outputPath);

            Console.WriteLine($"SVG has been converted to PDF successfully: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}