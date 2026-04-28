// Provide a base URL in HtmlLoadOptions when converting MHTML to ensure relative links resolve correctly in the PDF.

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
            string sourcePath = "input.mhtml";
            // Path where the resulting PDF will be saved
            string outputPath = "output.pdf";

            // Open the MHTML file as a read‑only stream
            using (FileStream stream = File.OpenRead(sourcePath))
            {
                // Create PDF save options (default settings)
                PdfSaveOptions pdfOptions = new PdfSaveOptions();

                // Convert the MHTML stream to PDF
                Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}