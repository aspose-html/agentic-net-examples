// Convert EPUB to GIF and append conversion results, including file size and duration, to an audit log.

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
            string inputPath = "sample.epub";
            string outputPath = "output.gif";
            string auditLogPath = "audit.log";

            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Stopwatch stopwatch = Stopwatch.StartNew();
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                stopwatch.Stop();

                long fileSize = 0;
                if (File.Exists(outputPath))
                {
                    fileSize = new FileInfo(outputPath).Length;
                }

                string logEntry = $"Converted '{inputPath}' to '{outputPath}'. Size: {fileSize} bytes. Duration: {stopwatch.ElapsedMilliseconds} ms.{Environment.NewLine}";
                File.AppendAllText(auditLogPath, logEntry);
                Console.WriteLine("Conversion completed. Audit log updated.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}