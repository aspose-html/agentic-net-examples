// Create a reusable extension method that wraps Converter.ConvertMHTML with default options for quick usage.

using System;
using System.IO;

namespace AsposeHtmlExample
{
    public static class HTMLConversionExtensions
    {
        public static string ConvertMhtmlToPdf(this string inputPath, string outputPath)
        {
            // Default options for PDF conversion
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            using (var stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }
            return outputPath;
        }
    }

    public class Program
    {
        public static void Main()
        {
            try
            {
                // Prepare a minimal MHTML file (for demonstration purposes)
                string inputPath = "sample.mht";
                string htmlContent = "<html><body><p>Hello, Aspose.HTML!</p></body></html>";
                System.IO.File.WriteAllText(inputPath, htmlContent);

                // Define output PDF path
                string outputPath = "result.pdf";

                // Use the extension method for quick conversion
                string result = inputPath.ConvertMhtmlToPdf(outputPath);
                Console.WriteLine($"Conversion completed. Output file: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}