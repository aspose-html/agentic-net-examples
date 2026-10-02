// Render an MHTML email archive to PDF while preserving embedded images and styles.

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

            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "From: <sender@example.com>\r\nSubject: Test\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Hello</h1><img src=\"cid:image1\"/></body></html>\r\n------=_NextPart_000_0000\r\nContent-Type: image/png\r\nContent-Transfer-Encoding: base64\r\nContent-ID: <image1>\r\n\r\niVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XcZcAAAAASUVORK5CYII=\r\n------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            Stream stream = File.OpenRead(inputPath);
            PdfSaveOptions options = new PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            Console.WriteLine("Conversion completed. PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}