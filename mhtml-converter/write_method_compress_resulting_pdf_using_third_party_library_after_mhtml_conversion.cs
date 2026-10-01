// Write a method that compresses the resulting PDF using a third‑party library after MHTML conversion.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"From: <Saved by WebKit>
Subject: 
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, Aspose.HTML!</h1></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            ConvertMhtmlToPdf(inputPath, outputPdfPath);
            Console.WriteLine($"PDF generated at: {outputPdfPath}");

            CompressPdf(outputPdfPath);
            Console.WriteLine("PDF compressed into a ZIP archive.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToPdf(string inputPath, string outputPath)
    {
        using (FileStream stream = File.OpenRead(inputPath))
        {
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
        }
    }

    static void CompressPdf(string pdfPath)
    {
        if (!File.Exists(pdfPath))
        {
            Console.WriteLine("PDF file not found; cannot compress.");
            return;
        }

        string zipPath = pdfPath + ".zip";
        using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
        {
            ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(pdfPath));
            using (Stream entryStream = entry.Open())
            using (FileStream pdfStream = File.OpenRead(pdfPath))
            {
                pdfStream.CopyTo(entryStream);
            }
        }
    }
}