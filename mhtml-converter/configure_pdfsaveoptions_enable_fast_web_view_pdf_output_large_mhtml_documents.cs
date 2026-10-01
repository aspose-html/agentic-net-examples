// Configure PdfSaveOptions to enable fast web view for PDF output generated from large MHTML documents.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.pdf";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"From: <Saved by WebKit>
Subject: 
Date: Mon, 1 Jan 2024 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000_01D4C8A0.12345678""; type=""text/html""

------=_NextPart_000_0000_01D4C8A0.12345678
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: 8bit

<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body><h1>Hello, World!</h1></body>
</html>

------=_NextPart_000_0000_01D4C8A0.12345678--";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            // Open the MHTML file for reading
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Note: Fast web view is not directly supported by PdfSaveOptions in this version.
                // If a property becomes available, it can be set here, e.g., options.FastWebView = true;

                // Convert MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}