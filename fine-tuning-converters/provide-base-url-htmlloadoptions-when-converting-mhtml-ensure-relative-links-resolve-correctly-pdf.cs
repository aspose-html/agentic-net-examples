// Provide a base URL in HtmlLoadOptions when converting MHTML to ensure relative links resolve correctly in the PDF.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare temporary folder
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeMhtmlExample");
            Directory.CreateDirectory(tempDir);

            // Create a simple 1x1 PNG image
            byte[] pngBytes = Convert.FromBase64String(
                "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XcZcAAAAASUVORK5CYII=");
            string imagePath = Path.Combine(tempDir, "image.png");
            File.WriteAllBytes(imagePath, pngBytes);

            // Create a minimal MHTML file referencing the image with a relative link
            string mhtmlContent = @"From: <Saved by WebKit>
Subject: 
Date: 
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><img src=""image.png""/></body></html>
------=_NextPart_000_0000
Content-Type: image/png
Content-Transfer-Encoding: base64
Content-Location: image.png

iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XcZcAAAAASUVORK5CYII=
------=_NextPart_000_0000--";

            string mhtmlPath = Path.Combine(tempDir, "sample.mht");
            File.WriteAllText(mhtmlPath, mhtmlContent, Encoding.UTF8);

            // Output PDF path
            string outputPdf = Path.Combine(tempDir, "result.pdf");

            // Load MHTML document from file path
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(mhtmlPath))
            {
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPdf);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to:");
            Console.WriteLine(outputPdf);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}