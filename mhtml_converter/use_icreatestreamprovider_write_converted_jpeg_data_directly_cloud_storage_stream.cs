// Use ICreateStreamProvider to write converted JPEG data directly to a cloud storage stream.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source EPUB file
            string epubPath = "input.epub";

            // Open the EPUB file as a readable stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Set conversion options to JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Create a custom stream provider that captures output streams in memory
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Perform the conversion; each page is rendered to a separate memory stream
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Obtain a stream that writes directly to cloud storage
                    using (Stream cloudStream = GetCloudOutputStream())
                    {
                        // Retrieve the first generated JPEG image
                        MemoryStream firstImage = provider.Streams[0];
                        firstImage.Seek(0, SeekOrigin.Begin);
                        // Copy the image data to the cloud storage stream
                        firstImage.CopyTo(cloudStream);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Placeholder method that returns a stream representing cloud storage.
    // Replace this with actual cloud SDK logic (e.g., Azure Blob, AWS S3) as needed.
    static Stream GetCloudOutputStream()
    {
        // For demonstration purposes, write to a local file named "output.jpg"
        return File.Create("output.jpg");
    }
}

// Custom implementation of ICreateStreamProvider that stores each created MemoryStream.
class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    // Expose the captured streams for later access
    public IReadOnlyList<MemoryStream> Streams => _streams;

    // Required overload without page index
    public Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    // Required overload with page index (capacity parameter is not used here)
    public Stream GetStream(string name, string extension, int page)
    {
        var memoryStream = new MemoryStream();
        _streams.Add(memoryStream);
        return memoryStream;
    }

    // ReleaseStream is called by the converter; we keep streams alive for later use
    public void ReleaseStream(Stream stream)
    {
        // Intentionally left empty to prevent premature disposal
    }

    // Dispose all captured memory streams when the provider is disposed
    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
    }
}