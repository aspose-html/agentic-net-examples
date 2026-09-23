// Implement an asynchronous version of the extraction routine to improve scalability.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

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
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
    }
}

public class Program
{
    private const string InputPath = "sample.epub";
    private const string OutputPath = "output.xps";
    private const string LogPath = "conversion.log";

    public static async Task Main(string[] args)
    {
        try
        {
            await PerformConversionAsync(InputPath, OutputPath, LogPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task PerformConversionAsync(string inputPath, string outputPath, string logPath)
    {
        // Ensure input file exists (create a placeholder if missing)
        if (!File.Exists(inputPath))
        {
            File.WriteAllBytes(inputPath, new byte[0]);
        }

        using (Stream stream = File.OpenRead(inputPath))
        {
            var options = new Aspose.Html.Saving.XpsSaveOptions();
            var provider = new MemoryStreamProvider();

            var stopwatch = Stopwatch.StartNew();

            await Task.Run(() =>
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, provider);
            });

            stopwatch.Stop();

            File.AppendAllText(logPath, $"Conversion duration: {stopwatch.Elapsed}" + Environment.NewLine);

            if (provider.Streams.Count > 0)
            {
                var firstStream = provider.Streams[0];
                firstStream.Position = 0;
                using (var fileStream = File.Create(outputPath))
                {
                    firstStream.CopyTo(fileStream);
                }
            }

            provider.Dispose();
        }
    }
}