// Use PdfSaveOptions to embed a custom ICC profile for color management during MHTML to PDF conversion.

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

            using (Stream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                // Aspose.Html does not provide a direct property to embed an ICC profile.
                // If such a property existed, it would be set here.

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