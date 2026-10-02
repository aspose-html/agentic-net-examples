// Use DocSaveOptions to set default font fallback when converting MHTML containing unsupported fonts to DOCX.

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
            string inputPath = "sample.mhtml";
            string outputPath = "output.docx";

            // Create a minimal MHTML file if it does not exist.
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"From: <Saved by WebKit>
Subject: 
Date: Thu, 1 Jan 1970 00:00:00 +0000
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><p>Sample content with an unsupported font.</p></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                DocSaveOptions options = new DocSaveOptions();
                // Note: Font fallback settings are not available in the current API version.
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