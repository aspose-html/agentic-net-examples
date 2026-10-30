// Write code to convert MHTML to PDF and then embed a cover page generated from a separate HTML file.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string coverHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "cover.html");
            string sourceMhtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "source.mht");
            string coverPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "cover.pdf");
            string contentPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "content.pdf");
            string finalPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "final.pdf");

            // Ensure sample cover HTML exists
            if (!File.Exists(coverHtmlPath))
            {
                File.WriteAllText(coverHtmlPath, "<html><body><h1>Cover Page</h1><p>This is the cover.</p></body></html>");
            }

            // Ensure sample MHTML exists (minimal MHTML content)
            if (!File.Exists(sourceMhtmlPath))
            {
                string minimalMhtml = "From: <Saved by WebKit>\r\nSubject: \r\nDate: \r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000_01D4C8E0.6A2B3C40\"\r\n\r\n------=_NextPart_000_0000_01D4C8E0.6A2B3C40\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\n\r\n<html><body><p>Main content from MHTML.</p></body></html>\r\n------=_NextPart_000_0000_01D4C8E0.6A2B3C40--";
                File.WriteAllText(sourceMhtmlPath, minimalMhtml);
            }

            // Convert cover HTML to PDF
            Aspose.Html.Saving.PdfSaveOptions coverPdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(coverHtmlPath, coverPdfOptions, coverPdfPath);

            // Convert MHTML to PDF
            Aspose.Html.Saving.PdfSaveOptions contentPdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            using (System.IO.FileStream mhtmlStream = System.IO.File.OpenRead(sourceMhtmlPath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, contentPdfOptions, contentPdfPath);
            }

            // Merge cover PDF and content PDF into final PDF (simple concatenation)
            using (FileStream finalStream = File.Create(finalPdfPath))
            {
                using (FileStream coverStream = File.OpenRead(coverPdfPath))
                {
                    coverStream.CopyTo(finalStream);
                }
                using (FileStream contentStream = File.OpenRead(contentPdfPath))
                {
                    contentStream.CopyTo(finalStream);
                }
            }

            Console.WriteLine("Conversion completed. Final PDF saved at: " + finalPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}