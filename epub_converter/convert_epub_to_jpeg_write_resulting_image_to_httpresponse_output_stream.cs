// Convert EPUB to JPEG and write the resulting image directly to an HttpResponse output stream.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string path, string contentType)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string path, string contentType, int pageNumber)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for in‑memory streams
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
        Streams.Clear();
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Open the EPUB file as a stream
            using (Stream epubStream = File.OpenRead("sample.epub"))
            {
                // Set image save options to JPEG format
                var options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Create a custom stream provider that captures output streams in memory
                using (var provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to images; each page will be written to a memory stream
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Ensure at least one image was generated
                    if (provider.Streams.Count > 0)
                    {
                        // Get the first generated image stream
                        var resultStream = provider.Streams[0];
                        resultStream.Position = 0;

                        // Write the image directly to the external response output stream
                        // Here we use the console output stream as a placeholder for HttpResponse.OutputStream
                        using (Stream responseStream = Console.OpenStandardOutput())
                        {
                            resultStream.CopyTo(responseStream);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}