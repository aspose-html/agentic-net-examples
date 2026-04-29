// Capture conversion exceptions and log error messages with source file path for troubleshooting.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        string inputPath = "input.html";
        string outputPath = "output.pdf";
        try
        {
            var options = new PdfSaveOptions();
            Converter.ConvertHTML(inputPath, options, outputPath);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error converting file '{inputPath}': {ex.Message}");
        }
    }
}