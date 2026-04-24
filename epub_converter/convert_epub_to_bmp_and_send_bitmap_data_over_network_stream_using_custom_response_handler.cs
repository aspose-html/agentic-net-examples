// Convert EPUB to BMP and send the bitmap data over a network stream using a custom response handler.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    // Called by Aspose.HTML to obtain a stream for each output page
    public Stream GetStream(string path, string mimeType)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    // Overload with index parameter
    public Stream GetStream(string path, string mimeType, int index)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    // Called when Aspose.HTML releases a stream (no action needed here)
    public void ReleaseStream(Stream stream) { }

    // Dispose all stored memory streams
    public void Dispose()
    {
        foreach (var ms in _streams) ms.Dispose();
        _streams.Clear();
    }

    // Helper to retrieve the first generated BMP stream
    public MemoryStream GetFirstStream()
    {
        return _streams.FirstOrDefault();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Open the EPUB file as a read‑only stream
            using (var epubStream = File.OpenRead("input.epub"))
            {
                // Configure conversion to BMP format
                var options = new ImageSaveOptions(ImageFormat.Bmp);

                // Custom provider that captures generated image streams in memory
                using (var provider = new MemoryStreamProvider())
                {
                    // Perform the conversion; generated BMP pages are stored in the provider
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Retrieve the first BMP image (or handle multiple pages as needed)
                    var bmpStream = provider.GetFirstStream();
                    if (bmpStream == null)
                        throw new InvalidOperationException("No BMP image was generated.");

                    bmpStream.Position = 0; // Reset position before sending

                    // Example network transmission: send the BMP bytes to a TCP endpoint
                    using (var client = new TcpClient("localhost", 5000))
                    using (var networkStream = client.GetStream())
                    {
                        bmpStream.CopyTo(networkStream);
                        networkStream.Flush();
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