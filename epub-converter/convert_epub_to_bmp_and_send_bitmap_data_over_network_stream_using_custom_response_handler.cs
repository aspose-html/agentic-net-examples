// Convert EPUB to BMP and send the bitmap data over a network stream using a custom response handler.

using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Sockets;
using Aspose.Html.IO;

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
            // Input EPUB file (ensure this file exists or create a minimal one beforehand)
            const string epubPath = "sample.epub";

            // Network destination
            const string host = "localhost";
            const int port = 9000;

            // Open EPUB stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Set image save options to BMP
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Create custom stream provider to capture bitmap output in memory
                using (var provider = new MemoryStreamProvider())
                {
                    // Convert EPUB pages to BMP images stored in memory streams
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    if (provider.Streams.Count == 0)
                    {
                        Console.WriteLine("No bitmap streams were generated.");
                        return;
                    }

                    // Get the first generated bitmap stream
                    var bitmapStream = provider.Streams[0];
                    bitmapStream.Position = 0;

                    // Send bitmap data over a TCP network stream
                    using (var client = new TcpClient(host, port))
                    using (NetworkStream networkStream = client.GetStream())
                    {
                        bitmapStream.CopyTo(networkStream);
                    }

                    Console.WriteLine("Bitmap data sent successfully.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}