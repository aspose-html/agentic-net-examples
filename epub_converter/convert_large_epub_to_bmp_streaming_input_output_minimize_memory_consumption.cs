// Convert a large EPUB to BMP by streaming input and output to minimize memory consumption during conversion.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        stream?.Flush();
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
            ms.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Open EPUB file as a stream
            using Stream epubStream = File.OpenRead("input.epub");

            // Set conversion options to BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Create custom stream provider to capture output in memory
            using var provider = new MemoryStreamProvider();

            // Perform conversion
            Converter.ConvertEPUB(epubStream, options, provider);

            // Ensure at least one image was generated
            if (provider.Streams.Count == 0)
                throw new InvalidOperationException("No image streams were generated.");

            // Prepare the first generated image stream for reading
            MemoryStream imageStream = provider.Streams[0];
            imageStream.Position = 0;

            // Send the BMP image over a network stream (example: TCP to localhost:12345)
            using var client = new TcpClient("localhost", 12345);
            using NetworkStream networkStream = client.GetStream();

            // Copy image bytes to the network stream
            imageStream.CopyTo(networkStream);
            networkStream.Flush();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}