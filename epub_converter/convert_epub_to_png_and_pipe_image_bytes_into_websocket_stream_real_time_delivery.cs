// Convert EPUB to PNG and pipe the image bytes into a WebSocket stream for real‑time delivery.

using System;
using System.IO;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string path, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string path, string extension, int pageIndex)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are managed in the list.
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
    static async Task Main(string[] args)
    {
        try
        {
            string epubPath = "input.epub"; // Path to the EPUB file
            string webSocketUri = "ws://localhost:5000/epubimages"; // Destination WebSocket URI

            using var epubStream = File.OpenRead(epubPath);
            var options = new ImageSaveOptions(); // Default PNG format

            using var provider = new MemoryStreamProvider();

            Converter.ConvertEPUB(epubStream, options, provider);

            using var client = new ClientWebSocket();
            await client.ConnectAsync(new Uri(webSocketUri), CancellationToken.None);

            foreach (var memoryStream in provider.Streams)
            {
                byte[] imageBytes = memoryStream.ToArray();
                var buffer = new ArraySegment<byte>(imageBytes);
                await client.SendAsync(buffer, WebSocketMessageType.Binary, true, CancellationToken.None);
            }

            await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Done", CancellationToken.None);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}