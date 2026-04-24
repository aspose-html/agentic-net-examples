// Use Parallel.ForEach to process multiple pages concurrently while respecting thread safety.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly ConcurrentBag<MemoryStream> _streams = new ConcurrentBag<MemoryStream>();

    // Returns a new MemoryStream for each output page.
    public Stream GetStream(string path, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    // Overload with page number – also returns a new MemoryStream.
    public Stream GetStream(string path, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    // Called by Aspose when a stream is no longer needed.
    public void ReleaseStream(Stream stream)
    {
        // No special handling required; streams are kept for later saving.
    }

    // Expose the collected streams.
    public IEnumerable<MemoryStream> Streams => _streams;

    // Dispose all created streams.
    public void Dispose()
    {
        foreach (var ms in _streams)
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
            // Path to the source EPUB file.
            string epubPath = "sample.epub";

            // Configure image output as JPEG.
            var options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Create the custom stream provider.
            using var provider = new MemoryStreamProvider();

            // Convert the EPUB – each page will be written to a separate MemoryStream.
            Converter.ConvertEPUB(epubPath, options, provider);

            // Save each generated page stream to a separate JPEG file in parallel.
            int counter = 0;
            Parallel.ForEach(provider.Streams, stream =>
            {
                int pageIndex = Interlocked.Increment(ref counter);
                stream.Position = 0;
                string outputFile = $"page_{pageIndex}.jpg";
                using var fileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                stream.CopyTo(fileStream);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}