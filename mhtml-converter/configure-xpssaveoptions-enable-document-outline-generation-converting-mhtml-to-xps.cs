// Configure XpsSaveOptions to enable document outline generation when converting MHTML to XPS.

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
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mht");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"From: <Saved by WebKit>
Subject: Sample MHTML
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

            // Open the MHTML file as a read stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure XpsSaveOptions (no additional properties required for outline generation)
                XpsSaveOptions options = new XpsSaveOptions();

                // Perform the conversion
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