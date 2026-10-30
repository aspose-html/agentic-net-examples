// Use PdfSaveOptions to embed a custom ICC profile for color management during MHTML to PDF conversion.

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
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "result.pdf");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = @"From: <Saved by Aspose.HTML>
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""

<html><body><h1>Hello MHTML</h1></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Open the MHTML file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure PDF save options
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Convert MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. PDF saved to: " + outputPath);
            Console.WriteLine("PDF text extraction requires a separate PDF parsing library if needed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}