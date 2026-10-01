// Generate a BMP file from MHTML source while preserving original color depth using default options.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                string mhtmlContent = @"From: <saved by Aspose.HTML>
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""

<html><body><h1>Hello MHTML</h1></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine($"MHTML has been successfully converted to BMP: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}