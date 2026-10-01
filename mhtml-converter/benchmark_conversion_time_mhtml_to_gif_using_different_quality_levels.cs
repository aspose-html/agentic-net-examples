// Benchmark conversion time for MHTML to GIF using different ImageSaveOptions quality levels.

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare a minimal MHTML file
            string inputPath = "sample.mht";
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\r\nSubject: \r\nDate: \r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\n\r\n<html><body><h1>Hello World</h1></body></html>\r\n\r\n------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Create different ImageSaveOptions configurations
            var optionsList = new List<Aspose.Html.Saving.ImageSaveOptions>();

            var optDefault = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            optionsList.Add(optDefault);

            var optAA = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            optAA.UseAntialiasing = true;
            optionsList.Add(optAA);

            var optRes = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            optRes.HorizontalResolution = 150;
            optRes.VerticalResolution = 150;
            optionsList.Add(optRes);

            var optCombo = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            optCombo.UseAntialiasing = true;
            optCombo.HorizontalResolution = 150;
            optCombo.VerticalResolution = 150;
            optionsList.Add(optCombo);

            int index = 1;
            foreach (var options in optionsList)
            {
                string outputPath = $"output_{index}.gif";
                using (Stream stream = File.OpenRead(inputPath))
                {
                    var stopwatch = Stopwatch.StartNew();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    stopwatch.Stop();
                    Console.WriteLine($"Conversion {index}: {stopwatch.ElapsedMilliseconds} ms, output: {outputPath}");
                }
                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}