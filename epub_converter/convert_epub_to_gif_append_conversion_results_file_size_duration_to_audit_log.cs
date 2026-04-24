// Convert EPUB to GIF and append conversion results, including file size and duration, to an audit log.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input EPUB, output GIF and audit log
            string inputPath = "input.epub";
            string outputPath = "output.gif";
            string logPath = "audit.log";

            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Measure conversion duration
                Stopwatch sw = Stopwatch.StartNew();

                // Convert EPUB to GIF using Aspose.HTML
                Converter.ConvertEPUB(stream, options, outputPath);

                sw.Stop();

                // Get size of the generated GIF file
                long fileSize = new FileInfo(outputPath).Length;

                // Prepare audit log entry
                string logEntry = $"{DateTime.Now}: Converted '{inputPath}' to '{outputPath}'. " +
                                  $"Size: {fileSize} bytes. Duration: {sw.ElapsedMilliseconds} ms.{Environment.NewLine}";

                // Append entry to the audit log
                File.AppendAllText(logPath, logEntry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}