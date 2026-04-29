// Implement logging of conversion parameters such as output format and save options for audit trails.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "input.html";
            string outputPath = "output.pdf";

            // Choose output format and corresponding save options
            string outputFormat = "PDF";
            PdfSaveOptions options = new PdfSaveOptions();

            // Log conversion parameters
            Console.WriteLine($"Conversion started:");
            Console.WriteLine($"Input file: {Path.GetFullPath(inputHtmlPath)}");
            Console.WriteLine($"Output format: {outputFormat}");
            Console.WriteLine($"Save options type: {options.GetType().FullName}");

            // Perform conversion
            Converter.ConvertHTML(inputHtmlPath, options, outputPath);

            Console.WriteLine($"Conversion completed. Output file: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}