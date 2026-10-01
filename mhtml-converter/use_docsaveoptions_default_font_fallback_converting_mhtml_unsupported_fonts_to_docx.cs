// Use DocSaveOptions to set default font fallback when converting MHTML containing unsupported fonts to DOCX.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.docx";

            if (!File.Exists(inputPath))
            {
                string mhtmlContent = @"From: <Saved by WebKit>
Subject: Sample
Date: Mon, 01 Jan 2024 00:00:00 +0000
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><p>Hello World</p></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.DocSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}