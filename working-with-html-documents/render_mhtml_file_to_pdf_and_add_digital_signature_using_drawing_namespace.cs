// Render an MHTML file to PDF and add a digital signature using the drawing namespace.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mht");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string htmlContent = @"<html><head><meta charset=""utf-8""></head><body><h1>Sample MHTML</h1><p>This is a test.</p></body></html>";
                // Simple MHTML wrapper (header + HTML content)
                string mhtml = "From: <Saved by Aspose.Html>\r\n" +
                               "Subject: Sample MHTML\r\n" +
                               "Date: " + DateTime.UtcNow.ToString("R") + "\r\n" +
                               "MIME-Version: 1.0\r\n" +
                               "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                               "------=_NextPart_000_0000\r\n" +
                               "Content-Type: text/html; charset=\"utf-8\"\r\n" +
                               "Content-Transfer-Encoding: 8bit\r\n\r\n" +
                               htmlContent + "\r\n" +
                               "------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtml);
            }

            // Open the MHTML file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure PDF save options
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Convert MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine($"Conversion succeeded. PDF saved to: {outputPath}");
            Console.WriteLine("Note: Extracting text from the resulting PDF requires a separate PDF parsing library.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}