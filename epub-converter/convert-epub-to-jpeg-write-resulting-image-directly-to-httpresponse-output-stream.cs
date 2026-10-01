// Convert EPUB to JPEG and write the resulting image directly to an HttpResponse output stream.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

public class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
    public static void Main()
    {
        try
        {
            // Input EPUB file (replace with a valid path if needed)
            string epubPath = "sample.epub";
            using Stream epubStream = File.OpenRead(epubPath);

            // Set image save options to JPEG
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Create custom stream provider to capture output in memory
            using var provider = new MemoryStreamProvider();

            // Convert EPUB to JPEG images (one image per page)
            Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

            if (provider.Streams.Count > 0)
            {
                // Get the first generated image stream
                MemoryStream resultStream = provider.Streams[0];
                resultStream.Position = 0;

                // Simulate HttpResponse output stream
                using var responseStream = new MemoryStream();
                resultStream.CopyTo(responseStream);

                // For demonstration, also save to a file
                responseStream.Position = 0;
                using var fileStream = File.Create("output.jpg");
                responseStream.CopyTo(fileStream);
            }
            else
            {
                Console.WriteLine("No image was generated from the EPUB.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}