// Develop a logging interceptor that records Converter method entry and exit timestamps for performance metrics.

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

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
            // Prepare input EPUB file (dummy content for demonstration)
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // minimal ZIP header
            }

            // Open input stream
            Stream stream = File.OpenRead(inputPath);

            // Set up XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Create custom stream provider
            MemoryStreamProvider provider = new MemoryStreamProvider();

            // Record start time
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, provider);

            // Record end time
            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            Console.WriteLine($"Conversion elapsed time: {elapsed}");

            // Write first generated stream to output file
            string outputPath = "output.xps";
            if (provider.Streams.Count > 0)
            {
                using (Stream outputFile = File.Create(outputPath))
                {
                    MemoryStream firstStream = provider.Streams[0];
                    firstStream.Position = 0;
                    firstStream.CopyTo(outputFile);
                }
                Console.WriteLine($"First XPS output written to: {outputPath}");
            }
            else
            {
                Console.WriteLine("No output streams were generated.");
            }

            // Cleanup
            provider.Dispose();
            stream.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}