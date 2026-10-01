// Configure ImageSaveOptions to set compression level for BMP output when converting MHTML files.

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
            string inputPath = "input.mhtml";
            string outputPath = "output.bmp";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = @"From: <Saved by Aspose.HTML>
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""

<html><body><h1>Hello BMP</h1></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                // Optional rendering properties
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}