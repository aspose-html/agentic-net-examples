// Log conversion parameters, including source path, target format, and duration, to a JSON file.

using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace AsposeHtmlConversionLogger
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "input.html";
                string targetFormat = "pdf";
                string logPath = "conversion_log.json";

                Stopwatch sw = Stopwatch.StartNew();
                // Placeholder for actual conversion logic
                sw.Stop();

                var log = new
                {
                    SourcePath = sourcePath,
                    TargetFormat = targetFormat,
                    DurationSeconds = sw.Elapsed.TotalSeconds
                };

                string json = JsonSerializer.Serialize(log, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(logPath, json);
                Console.WriteLine("Conversion parameters logged to " + logPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}