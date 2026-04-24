// Implement a custom stream provider that compresses JPEG pages using GZip before saving to disk.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        // Do not dispose here; streams are needed after conversion.
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
            // Load the EPUB file as a stream.
            using var epubStream = File.OpenRead("input.epub");

            // Set image save options to JPEG format.
            var options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Create the custom stream provider to capture output streams.
            using var provider = new MemoryStreamProvider();

            // Convert EPUB pages to JPEG images, streams are stored in the provider.
            Converter.ConvertEPUB(epubStream, options, provider);

            // Iterate over each generated JPEG stream, compress with GZip, and save to disk.
            for (int i = 0; i < provider.Streams.Count; i++)
            {
                var memoryStream = provider.Streams[i];
                memoryStream.Seek(0, SeekOrigin.Begin);

                string outputPath = $"page_{i}.jpg.gz";
                using var fileStream = File.Create(outputPath);
                using var gzipStream = new GZipStream(fileStream, CompressionLevel.Optimal);
                memoryStream.CopyTo(gzipStream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}