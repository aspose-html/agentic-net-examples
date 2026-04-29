// Create a reusable configuration file that stores default PdfSaveOptions values for all MHTML conversions.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

static class PdfSaveOptionsProvider
{
    public static PdfSaveOptions GetDefaultOptions()
    {
        var options = new PdfSaveOptions();
        // Set any default values here if needed, e.g. options.PageSize = Aspose.Html.Rendering.Pdf.PageSize.A4;
        return options;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.mhtml";
            string outputPath = "output.pdf";

            using (FileStream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = PdfSaveOptionsProvider.GetDefaultOptions();
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML to PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}