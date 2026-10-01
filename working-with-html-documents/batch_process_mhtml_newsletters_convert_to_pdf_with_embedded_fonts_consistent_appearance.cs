// Batch process MHTML newsletters, converting each to PDF with embedded fonts for consistent appearance.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample MHTML file
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            Directory.CreateDirectory(inputFolder);
            string mhtmlPath = Path.Combine(inputFolder, "sample.mhtml");
            if (!File.Exists(mhtmlPath))
            {
                // Minimal MHTML content with a simple HTML page
                string mhtmlContent = @"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(mhtmlPath, mhtmlContent);
            }

            // Prepare output folder
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputFolder);
            string pdfPath = Path.Combine(outputFolder, "result.pdf");

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.IUserAgentService userAgentService = configuration.GetService<Aspose.Html.Services.IUserAgentService>();
            string fontsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            userAgentService.FontsSettings.SetFontsLookupFolder(fontsFolder);

            // Convert MHTML to PDF
            using (FileStream mhtmlStream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, pdfOptions, pdfPath);
            }

            Console.WriteLine($"MHTML file has been successfully converted to PDF at: {pdfPath}");
            Console.WriteLine("Note: Extracting text from the resulting PDF requires a separate PDF parsing library, which is not included in this example.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}