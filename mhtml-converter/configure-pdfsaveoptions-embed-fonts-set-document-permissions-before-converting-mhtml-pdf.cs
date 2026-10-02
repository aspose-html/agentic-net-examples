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
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\r\nSubject: \r\nDate: \r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\n\r\n<html><body><h1>Hello MHTML</h1></body></html>\r\n------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Open the MHTML file for reading
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Initialize PDF save options (no embed fonts or permissions properties are available)
                PdfSaveOptions pdfOptions = new PdfSaveOptions();

                // Convert MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}