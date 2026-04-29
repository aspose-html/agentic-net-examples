// Implement a method that returns a stream containing the converted JPEG image for further processing.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public Stream GetStream(string path, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string path, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are managed internally.
    }

    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();

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
            // Example usage: replace with actual EPUB file path.
            string epubPath = "sample.epub";
            using (FileStream epubFileStream = File.OpenRead(epubPath))
            {
                using (Stream jpegStream = GetJpegFromEpub(epubFileStream))
                {
                    // jpegStream now contains the JPEG image data.
                    // For demonstration, write it to a file.
                    using (FileStream output = File.Create("output.jpg"))
                    {
                        jpegStream.CopyTo(output);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Stream GetJpegFromEpub(Stream epubStream)
    {
        // Configure image save options for JPEG format.
        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

        // Create custom stream provider to capture output streams.
        using (MemoryStreamProvider provider = new MemoryStreamProvider())
        {
            // Perform conversion.
            Converter.ConvertEPUB(epubStream, options, provider);

            // Retrieve the first generated memory stream.
            if (provider.Streams.Count == 0)
                throw new InvalidOperationException("No output streams were generated.");

            MemoryStream result = provider.Streams[0];
            result.Position = 0; // Reset position for reading.

            // Return a copy of the memory stream to avoid disposing it with the provider.
            MemoryStream copy = new MemoryStream();
            result.CopyTo(copy);
            copy.Position = 0;
            return copy;
        }
    }
}