// Log conversion duration and output file path using a structured logger after each MHTML conversion.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMhtml";
            string outputFolder = "OutputDocx";
            Directory.CreateDirectory(outputFolder);

            foreach (string mhtmlPath in Directory.GetFiles(inputFolder, "*.mhtml"))
            {
                string outputPath = Path.ChangeExtension(Path.Combine(outputFolder, Path.GetFileName(mhtmlPath)), ".docx");
                Stopwatch sw = Stopwatch.StartNew();
                ConvertMhtmlToDocx(mhtmlPath, outputPath);
                sw.Stop();
                LogConversion(sw.Elapsed, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToDocx(string inputPath, string outputPath)
    {
        using (FileStream stream = File.OpenRead(inputPath))
        {
            DocSaveOptions options = new DocSaveOptions();
            Converter.ConvertMHTML(stream, options, outputPath);
        }
    }

    static void LogConversion(TimeSpan duration, string outputPath)
    {
        var logEntry = new
        {
            Timestamp = DateTime.UtcNow,
            DurationMs = duration.TotalMilliseconds,
            OutputPath = outputPath
        };
        Console.WriteLine(JsonSerializer.Serialize(logEntry));
    }
}