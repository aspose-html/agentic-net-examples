// Develop a logging interceptor that records Converter method entry and exit timestamps for performance metrics.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        // No action needed; streams are kept for later use.
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

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input EPUB file (minimal placeholder)
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Open input stream
            Stream inputStream = File.OpenRead(inputPath);

            // Set up save options for XPS output
            XpsSaveOptions options = new XpsSaveOptions();

            // Create custom stream provider to capture output in memory
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Record start time
                DateTime startTime = DateTime.UtcNow;

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                // Record end time
                DateTime endTime = DateTime.UtcNow;
                TimeSpan elapsed = endTime - startTime;
                Console.WriteLine($"Conversion elapsed time: {elapsed.TotalMilliseconds} ms");

                // Write first generated memory stream to file
                if (provider.Streams.Count > 0)
                {
                    MemoryStream firstStream = provider.Streams[0];
                    firstStream.Position = 0;
                    string outputPath = "output.xps";
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        firstStream.CopyTo(fileStream);
                    }
                    Console.WriteLine($"Output written to: {outputPath}");
                }
                else
                {
                    Console.WriteLine("No output streams were generated.");
                }
            }

            inputStream.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}