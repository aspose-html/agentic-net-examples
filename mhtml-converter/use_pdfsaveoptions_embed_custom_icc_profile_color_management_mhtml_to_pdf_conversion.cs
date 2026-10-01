// Use PdfSaveOptions to embed a custom ICC profile for color management during MHTML to PDF conversion.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

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
                string mhtmlContent = @"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, MHTML to PDF!</h1></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Open the MHTML file for reading
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure PDF save options
                PdfSaveOptions options = new PdfSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Convert MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}