// Transform MHTML content into a high‑resolution PNG image using ImageSaveOptions with DPI settings.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        System.IO.Stream stream = null;
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.png";

            // Create a minimal MHTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string minimalMhtml = @"From: <Saved by WebKit>
Subject: 
Date: 
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000_01D4C0A0.12345678""; type=""text/html""

------=_NextPart_000_0000_01D4C0A0.12345678
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, MHTML!</h1></body></html>

------=_NextPart_000_0000_01D4C0A0.12345678--";
                System.IO.File.WriteAllText(inputPath, minimalMhtml);
            }

            stream = System.IO.File.OpenRead(inputPath);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.HorizontalResolution = 300; // DPI
            options.VerticalResolution = 300;   // DPI
            options.UseAntialiasing = true;

            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);

            Console.WriteLine("MHTML has been converted to high‑resolution PNG: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (stream != null)
            {
                stream.Dispose();
            }
        }
    }
}