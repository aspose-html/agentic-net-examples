// Implement a feature that writes conversion logs to a JSON file for downstream processing.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string path, string contentType)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string path, string contentType, int bufferSize)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No special handling required.
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string inputPath = "sample.epub";
            string outputPath = "output.xps";
            string logPath = "conversion_log.json";

            // Open the EPUB file stream
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Set conversion options
                XpsSaveOptions options = new XpsSaveOptions();

                // Create custom stream provider to capture output streams
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Measure conversion time
                    DateTime start = DateTime.UtcNow;
                    Converter.ConvertEPUB(epubStream, options, provider);
                    DateTime end = DateTime.UtcNow;
                    TimeSpan elapsed = end - start;

                    // Write the first generated XPS stream to the output file
                    if (provider.Streams.Count > 0)
                    {
                        provider.Streams[0].Position = 0;
                        using (FileStream fileOut = File.Create(outputPath))
                        {
                            provider.Streams[0].CopyTo(fileOut);
                        }
                    }

                    // Prepare log information
                    var log = new
                    {
                        InputFile = inputPath,
                        OutputFile = outputPath,
                        ElapsedMilliseconds = elapsed.TotalMilliseconds
                    };

                    // Serialize log to JSON and write to file
                    string json = JsonSerializer.Serialize(log, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(logPath, json);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}