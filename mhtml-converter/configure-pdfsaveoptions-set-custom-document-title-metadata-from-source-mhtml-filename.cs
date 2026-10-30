// Configure PdfSaveOptions to set a custom document title metadata based on the source MHTML filename.

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
            string inputPath = "sample.mhtml";
            string outputPath = "output.pdf";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "From: <saved by Aspose.HTML>\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000_01D6C0E0.12345678\"\r\n\r\n------=_NextPart_000_0000_01D6C0E0.12345678\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><p>Hello, MHTML!</p></body></html>\r\n------=_NextPart_000_0000_01D6C0E0.12345678--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions pdfOptions = new PdfSaveOptions();

                // Set PDF document title based on the source MHTML filename
                string title = Path.GetFileNameWithoutExtension(inputPath);
                pdfOptions.DocumentInfo.Title = title;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }

            Console.WriteLine("Conversion completed. PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}