// Implement a feature that writes conversion logs to a JSON file for downstream processing.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html.IO;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are retained for later use.
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.xps";
            string logPath = "conversion_log.json";

            // Ensure a minimal input file exists.
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                var provider = new MemoryStreamProvider();

                DateTime startTime = DateTime.UtcNow;
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, provider);
                DateTime endTime = DateTime.UtcNow;
                double durationMs = (endTime - startTime).TotalMilliseconds;

                // Write the first generated stream to the output file.
                if (provider.Streams.Count > 0)
                {
                    var firstStream = provider.Streams[0];
                    firstStream.Position = 0;
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        firstStream.CopyTo(fileStream);
                    }
                }

                var logEntry = new
                {
                    InputFile = inputPath,
                    OutputFile = outputPath,
                    StartTime = startTime,
                    EndTime = endTime,
                    DurationMs = durationMs
                };

                string json = JsonSerializer.Serialize(logEntry, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(logPath, json);
            }
        }
        catch (Exception ex)
        {
            var errorLog = new
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace,
                Time = DateTime.UtcNow
            };
            string json = JsonSerializer.Serialize(errorLog, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("conversion_log.json", json);
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}