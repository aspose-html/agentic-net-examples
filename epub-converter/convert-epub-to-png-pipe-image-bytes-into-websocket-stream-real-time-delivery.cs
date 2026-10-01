// Convert EPUB to PNG and pipe the image bytes into a WebSocket stream for real‑time delivery.

using System;
using System.IO;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
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
        // No action needed; streams are retained for later use.
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
    static void Main(string[] args)
    {
        try
        {
            // Input EPUB file (ensure the file exists at the specified path)
            string epubPath = "sample.epub";
            using Stream epubStream = File.OpenRead(epubPath);

            // Configure image save options (default format is PNG)
            var options = new Aspose.Html.Saving.ImageSaveOptions();

            // Create a custom stream provider to capture in‑memory PNG images
            using var provider = new MemoryStreamProvider();

            // Convert EPUB pages to PNG images stored in the provider
            Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

            // Connect to a WebSocket server for real‑time delivery
            var wsUri = new Uri("ws://localhost:5000/epub");
            using var client = new ClientWebSocket();
            client.ConnectAsync(wsUri, CancellationToken.None).GetAwaiter().GetResult();

            // Send each generated PNG image as a binary message
            foreach (var memoryStream in provider.Streams)
            {
                memoryStream.Position = 0;
                byte[] imageBytes = memoryStream.ToArray();
                var buffer = new ArraySegment<byte>(imageBytes);
                client.SendAsync(buffer, WebSocketMessageType.Binary, true, CancellationToken.None)
                      .GetAwaiter()
                      .GetResult();
            }

            // Close the WebSocket connection gracefully
            client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Completed", CancellationToken.None)
                  .GetAwaiter()
                  .GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}