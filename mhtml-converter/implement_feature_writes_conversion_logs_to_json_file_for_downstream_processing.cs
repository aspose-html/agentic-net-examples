// Implement a feature that writes conversion logs to a JSON file for downstream processing.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.xps";
            string logPath = "conversion_log.json";

            // Ensure a minimal sample input file exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (var inputStream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.XpsSaveOptions();
                var provider = new MemoryStreamProvider();

                DateTime startTime = DateTime.UtcNow;
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);
                DateTime endTime = DateTime.UtcNow;
                double elapsedMs = (endTime - startTime).TotalMilliseconds;

                // Write the first generated stream to the output file
                if (provider.Streams.Count > 0)
                {
                    var firstStream = provider.Streams[0];
                    firstStream.Position = 0;
                    using (var fileStream = System.IO.File.Create(outputPath))
                    {
                        firstStream.CopyTo(fileStream);
                    }
                }

                var log = new
                {
                    StartTimeUtc = startTime,
                    EndTimeUtc = endTime,
                    ElapsedMilliseconds = elapsedMs,
                    OutputFile = Path.GetFullPath(outputPath)
                };

                string json = JsonSerializer.Serialize(log, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(logPath, json);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}