// Configure PdfSaveOptions to enable fast web view for PDF output generated from large MHTML documents.

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
            // Define input MHTML and output PDF paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "sample.mhtml");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "result.pdf");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"From: <saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Sample MHTML Content</h1></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            // Open the MHTML file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Enable Fast Web View if the property exists (using reflection for compatibility)
                var fastWebViewProp = typeof(PdfSaveOptions).GetProperty("FastWebView");
                if (fastWebViewProp != null && fastWebViewProp.CanWrite)
                {
                    fastWebViewProp.SetValue(options, true);
                }

                // Convert MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}