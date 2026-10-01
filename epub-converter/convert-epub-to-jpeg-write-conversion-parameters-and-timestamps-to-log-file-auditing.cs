// Convert EPUB to JPEG and write conversion parameters and timestamps to a log file for auditing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dataDir = Path.Combine(baseDir, "Data");
            string outputDir = Path.Combine(baseDir, "Output");
            string logFile = Path.Combine(baseDir, "conversion.log");

            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "output.jpg");

            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (FileStream stream = File.OpenRead(epubPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            string logEntry = $"{DateTime.UtcNow:O} | Input: {epubPath} | Output: {outputPath} | Format: JPEG";
            File.AppendAllText(logFile, logEntry + Environment.NewLine);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}