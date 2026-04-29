// Configure PdfSaveOptions to enable fast web view for PDF output generated from large MHTML documents.

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
            // Path to the source MHTML file
            string inputPath = "input.mhtml";
            // Desired output PDF file path
            string outputPath = "output.pdf";

            // Open the MHTML file as a read‑only stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create PDF save options (FastWebView not available in this version)
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert the MHTML stream to PDF using the specified options
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}