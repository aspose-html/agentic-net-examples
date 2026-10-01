// Convert EPUB to BMP and send the bitmap data over a network stream using a custom response handler.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

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
        _streams.Clear();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "sample.epub";

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                if (provider.Streams.Count > 0)
                {
                    MemoryStream firstStream = provider.Streams[0];
                    firstStream.Position = 0;

                    using (MemoryStream networkStream = new MemoryStream())
                    {
                        firstStream.CopyTo(networkStream);
                        Console.WriteLine($"Sent {networkStream.Length} bytes over network stream.");
                    }
                }
                else
                {
                    Console.WriteLine("No image streams were generated.");
                }

                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}