// Develop a test that measures CPU usage during bulk conversion of MHTML files to GIF format.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input files
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            int fileCount = 5;
            for (int i = 0; i < fileCount; i++)
            {
                string inputPath = Path.Combine(inputDir, $"sample{i + 1}.mht");
                // Minimal MHTML content (simple HTML wrapped in MHTML headers)
                string mhtmlContent = @"From: <Saved by WebKit>
Subject: 
Date: Mon, 1 Jan 2020 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000_01D4C0A0.00000000""; type=""text/html""

------=_NextPart_000_0000_01D4C0A0.00000000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Sample MHTML {0}</h1><p>This is a test.</p></body></html>

------=_NextPart_000_0000_01D4C0A0.00000000--";
                File.WriteAllText(inputPath, string.Format(mhtmlContent, i + 1));
            }

            // Measure CPU usage
            Process process = Process.GetCurrentProcess();
            TimeSpan cpuStart = process.TotalProcessorTime;

            for (int i = 0; i < fileCount; i++)
            {
                string inputPath = Path.Combine(inputDir, $"sample{i + 1}.mht");
                string outputPath = Path.Combine(outputDir, $"output{i + 1}.gif");

                using (FileStream stream = File.OpenRead(inputPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
            }

            TimeSpan cpuEnd = process.TotalProcessorTime;
            TimeSpan cpuUsed = cpuEnd - cpuStart;

            Console.WriteLine($"CPU time used for converting {fileCount} MHTML files to GIF: {cpuUsed.TotalMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}