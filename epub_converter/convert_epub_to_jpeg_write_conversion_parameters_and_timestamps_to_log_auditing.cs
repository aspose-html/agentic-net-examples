// Convert EPUB to JPEG and write conversion parameters and timestamps to a log file for auditing.

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
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubFile = Path.Combine(dataDir, "sample.epub");
            string outputFile = Path.Combine(outputDir, "sample.jpg");
            string logFile = Path.Combine(outputDir, "conversion.log");

            using (FileStream stream = File.OpenRead(epubFile))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Converter.ConvertEPUB(stream, options, outputFile);
            }

            string logEntry = $"{DateTime.UtcNow:O}\tInput:{epubFile}\tOutput:{outputFile}\tFormat:Jpeg{Environment.NewLine}";
            File.AppendAllText(logFile, logEntry);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}