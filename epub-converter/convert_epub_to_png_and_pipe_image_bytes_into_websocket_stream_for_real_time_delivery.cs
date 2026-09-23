// Convert EPUB to PNG and pipe the image bytes into a WebSocket stream for real‑time delivery.

using System;
using System.IO;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
}

public class Program
{
    public static async Task Main()
    {
        try
        {
            string epubPath = "sample.epub";

            if (!File.Exists(epubPath))
            {
                // Create a minimal placeholder EPUB file
                File.WriteAllBytes(epubPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // ZIP header bytes
            }

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(); // PNG is default
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                var wsUri = new Uri("ws://localhost:5000/");
                using (var client = new ClientWebSocket())
                {
                    await client.ConnectAsync(wsUri, CancellationToken.None);

                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        byte[] buffer = ms.ToArray();
                        var segment = new ArraySegment<byte>(buffer);
                        await client.SendAsync(segment, WebSocketMessageType.Binary, true, CancellationToken.None);
                    }

                    await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Done", CancellationToken.None);
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