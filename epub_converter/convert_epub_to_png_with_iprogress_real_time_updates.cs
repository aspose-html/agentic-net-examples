// Convert EPUB to PNG and implement IProgress interface to receive real‑time updates from the conversion process.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();
    private readonly IProgress<int> _progress;

    public MemoryStreamProvider(IProgress<int> progress)
    {
        _progress = progress;
    }

    // Called by Aspose.HTML when a new output stream is required (no page number)
    public Stream GetStream(string path, string extension)
    {
        return GetStream(path, extension, 0);
    }

    // Called by Aspose.HTML when a new output stream is required for a specific page
    public Stream GetStream(string path, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        // Report progress: number of pages rendered so far
        _progress?.Report(_streams.Count);
        return ms;
    }

    // Called after the stream is no longer needed
    public void ReleaseStream(Stream stream)
    {
        // No additional cleanup required here
    }

    // Expose the collected memory streams
    public IReadOnlyList<MemoryStream> Streams => _streams;

    // Dispose all created streams
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
        // Path to the source EPUB file (replace with actual path)
        const string epubPath = "sample.epub";

        // Progress reporter that writes updates to the console
        var progress = new Progress<int>(p => Console.WriteLine($"Rendered page {p}"));

        try
        {
            // Open the EPUB file as a readable stream
            using var epubStream = File.OpenRead(epubPath);

            // Configure image saving options (default is PNG)
            var options = new ImageSaveOptions();

            // Provider that captures each rendered page into a MemoryStream
            using var provider = new MemoryStreamProvider(progress);

            // Perform the conversion: EPUB -> PNG images (one per page)
            Converter.ConvertEPUB(epubStream, options, provider);

            // Save each generated PNG image from memory to a file
            for (int i = 0; i < provider.Streams.Count; i++)
            {
                string outputFile = $"page_{i + 1}.png";
                File.WriteAllBytes(outputFile, provider.Streams[i].ToArray());
                Console.WriteLine($"Saved {outputFile}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}