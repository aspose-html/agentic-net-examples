// Use DocSaveOptions to set document language property when converting MHTML to DOCX for localization.

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
            // Define input and output paths
            string inputPath = "sample.mht";
            string outputPath = "result.docx";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = 
@"From: <Saved by WebKit>
Subject: 
Date: Thu, 1 Jan 1970 00:00:00 +0000
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""

<html><body><p>Hello World</p></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Open the MHTML file stream
            using (Stream inputStream = File.OpenRead(inputPath))
            {
                // Create DocSaveOptions (no language property available)
                DocSaveOptions saveOptions = new DocSaveOptions();

                // Convert MHTML to DOCX
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, saveOptions, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}