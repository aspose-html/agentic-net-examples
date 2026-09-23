// Convert EPUB to JPEG and write conversion parameters and timestamps to a log file for auditing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string inputFile = Path.Combine(dataDir, "sample.epub");
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "output.jpg");
            string logPath = Path.Combine(outputDir, "conversion.log");

            // Ensure sample EPUB exists (placeholder content)
            if (!File.Exists(inputFile))
            {
                Directory.CreateDirectory(dataDir);
                File.WriteAllBytes(inputFile, new byte[0]);
            }

            using (FileStream stream = File.OpenRead(inputFile))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                string startTime = DateTime.UtcNow.ToString("o");
                File.AppendAllText(logPath, $"Conversion started: {startTime}{Environment.NewLine}");
                File.AppendAllText(logPath, $"Input file: {inputFile}{Environment.NewLine}");
                File.AppendAllText(logPath, $"Output file: {outputPath}{Environment.NewLine}");
                File.AppendAllText(logPath, $"Image format: Jpeg{Environment.NewLine}");

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

                string endTime = DateTime.UtcNow.ToString("o");
                File.AppendAllText(logPath, $"Conversion completed: {endTime}{Environment.NewLine}");
            }

            Console.WriteLine("EPUB conversion to JPEG completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}