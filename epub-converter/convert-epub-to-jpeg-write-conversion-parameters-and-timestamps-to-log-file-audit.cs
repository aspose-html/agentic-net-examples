// Convert EPUB to JPEG and write conversion parameters and timestamps to a log file for auditing.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define directories and file paths
            string dataDir = "Data";
            string outputDir = "Output";
            string logPath = Path.Combine(outputDir, "conversion.log");
            string inputPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "output.jpg");

            // Ensure directories exist
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            // Log start timestamp and parameters
            string startTime = DateTime.UtcNow.ToString("o");
            string logEntryStart = $"StartTime: {startTime}{Environment.NewLine}" +
                                   $"InputFile: {inputPath}{Environment.NewLine}" +
                                   $"OutputFile: {outputPath}{Environment.NewLine}" +
                                   $"Format: JPEG{Environment.NewLine}";
            File.AppendAllText(logPath, logEntryStart);

            // Open EPUB file stream
            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                // Set image save options for JPEG
                ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            // Log end timestamp
            string endTime = DateTime.UtcNow.ToString("o");
            string logEntryEnd = $"EndTime: {endTime}{Environment.NewLine}{new string('-', 40)}{Environment.NewLine}";
            File.AppendAllText(logPath, logEntryEnd);
        }
        catch (Exception ex)
        {
            // Log exception details
            string errorLogPath = Path.Combine("Output", "conversion.log");
            string errorEntry = $"ErrorTime: {DateTime.UtcNow.ToString("o")}{Environment.NewLine}" +
                                $"Message: {ex.Message}{Environment.NewLine}" +
                                $"StackTrace: {ex.StackTrace}{Environment.NewLine}{new string('-', 40)}{Environment.NewLine}";
            File.AppendAllText(errorLogPath, errorEntry);
            Console.WriteLine("An error occurred during conversion. See log for details.");
        }
    }
}