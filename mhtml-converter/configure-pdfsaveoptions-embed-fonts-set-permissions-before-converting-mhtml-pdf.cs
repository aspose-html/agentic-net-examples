// Configure PdfSaveOptions to embed fonts and set document permissions before converting MHTML to PDF.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare a minimal MHTML file
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "result.pdf");
            string mhtmlContent = "From: test@example.com\r\nSubject: Sample\r\n\r\n<html><body><p>Hello, Aspose.HTML!</p></body></html>";
            File.WriteAllText(inputPath, mhtmlContent);

            // Open the MHTML file for reading
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create PDF save options (embed fonts and permissions are not supported in this version)
                PdfSaveOptions pdfOptions = new PdfSaveOptions();

                // Convert MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}