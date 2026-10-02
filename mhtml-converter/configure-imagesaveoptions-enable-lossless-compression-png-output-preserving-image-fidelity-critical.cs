// Configure ImageSaveOptions to enable lossless compression for PNG output when preserving image fidelity is critical.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal MHTML file
            string inputPath = "sample.mhtml";
            string mhtmlContent = @"From: <Saved by WebKit>
Subject: 
Date: 
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello PNG</h1></body></html>
------=_NextPart_000_0000--";
            File.WriteAllText(inputPath, mhtmlContent);

            // Open the MHTML stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure ImageSaveOptions for PNG with lossless compression (default for PNG)
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                // Optional: enable antialiasing for better quality
                options.UseAntialiasing = true;

                // Define output file path
                string outputPath = "output.png";

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}