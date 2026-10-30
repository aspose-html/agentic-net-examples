// Export an MHTML document to PDF while preserving hyperlinks and interactive elements.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string mhtmlContent = 
@"From: <saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 +0000
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><a href=""https://example.com"">Example Link</a></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(sourcePath, mhtmlContent);
            }

            // Open the MHTML file for reading
            using (Stream stream = File.OpenRead(sourcePath))
            {
                // Configure PDF save options (default preserves hyperlinks)
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine($"Conversion succeeded. PDF saved to: {outputPath}");
            Console.WriteLine("Note: Extracting text from the resulting PDF requires a separate PDF parsing library if not already available.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}