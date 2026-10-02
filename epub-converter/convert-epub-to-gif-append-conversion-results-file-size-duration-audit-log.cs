// Convert EPUB to GIF and append conversion results, including file size and duration, to an audit log.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string inputPath = "sample.epub";
            string outputPath = "output.gif";
            string logPath = "audit.log";

            // Ensure input file exists (create empty placeholder if missing)
            if (!File.Exists(inputPath))
            {
                using (FileStream placeholder = File.Create(inputPath))
                {
                    // Empty placeholder file
                }
            }

            // Prepare conversion options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Measure conversion time
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Perform conversion
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            sw.Stop();

            // Get output file size
            long fileSize = new FileInfo(outputPath).Length;

            // Append audit log
            using (StreamWriter logWriter = new StreamWriter(logPath, true))
            {
                logWriter.WriteLine($"{DateTime.Now}: Converted '{inputPath}' to '{outputPath}'. Size: {fileSize} bytes. Duration: {sw.Elapsed.TotalMilliseconds} ms.");
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}