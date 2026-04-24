// Use a custom ICreateStreamProvider to store GIF output directly into a cloud storage bucket.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class CloudGifStreamProvider : ICreateStreamProvider
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    // Provides a stream for rendering (no specific parameters needed for this example)
    public Stream GetStream(string path, string contentType)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    // Provides a stream for rendering with an index (not used here)
    public Stream GetStream(string path, string contentType, int index)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    // Releases the stream (no special handling required)
    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are managed internally.
    }

    // Dispose all created streams
    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }

    // Helper to retrieve the first generated GIF stream
    public MemoryStream GetFirstStream()
    {
        return _streams.Count > 0 ? _streams[0] : null;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Load EPUB file into a stream (replace with actual path or source)
            using (Stream epubStream = File.OpenRead("sample.epub"))
            {
                // Set conversion options to GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Create custom stream provider to capture output
                using (CloudGifStreamProvider provider = new CloudGifStreamProvider())
                {
                    // Perform conversion
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Retrieve the generated GIF stream
                    MemoryStream gifStream = provider.GetFirstStream();
                    if (gifStream != null)
                    {
                        // Reset position before reading/uploading
                        gifStream.Position = 0;

                        // TODO: Upload gifStream to cloud storage bucket
                        // Example placeholder:
                        // CloudStorage.Upload("bucket-name", "output.gif", gifStream);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}