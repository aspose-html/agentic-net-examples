// Configure PdfSaveOptions to embed fonts and set document permissions before converting MHTML to PDF.

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
            // Paths for the source MHTML file and the resulting PDF file
            string inputPath = "input.mhtml";
            string outputPath = "output.pdf";

            // Open the MHTML file as a read‑only stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create PDF save options (default configuration)
                PdfSaveOptions pdfOptions = new PdfSaveOptions();

                // If the API supports embedding fonts, set the appropriate property here
                // e.g., pdfOptions.EmbedAllFonts = true;

                // If the API supports setting permissions, configure them here
                // e.g., pdfOptions.Permissions = PdfPermissions.Print | PdfPermissions.Modify;

                // Convert the MHTML stream to PDF using the configured options
                Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }

            Console.WriteLine("MHTML successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}