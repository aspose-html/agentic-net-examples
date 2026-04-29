// Load an MHTML file from disk and convert it to PDF using default settings.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.mhtml";
            string outputPath = "output.pdf";

            FileStream stream = File.OpenRead(inputPath);
            PdfSaveOptions options = new PdfSaveOptions();
            Converter.ConvertMHTML(stream, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}