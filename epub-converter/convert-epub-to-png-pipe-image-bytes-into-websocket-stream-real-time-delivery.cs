// Convert EPUB to PNG and pipe the image bytes into a WebSocket stream for real‑time delivery.

using System;
using System.IO;
using System.Collections.Generic;
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
    public static void Main(string[] args)
    {
        try
        {
            RunAsync().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task RunAsync()
    {
        const string epubPath = "sample.epub";

        // Ensure a sample EPUB file exists (empty placeholder)
        if (!File.Exists(epubPath))
        {
            using (var fs = File.Create(epubPath)) { }
        }

        using (Stream epubStream = File.OpenRead(epubPath))
        {
            var options = new Aspose.Html.Saving.ImageSaveOptions();
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                foreach (var memoryStream in provider.Streams)
                {
                    memoryStream.Position = 0;
                    byte[] imageBytes = memoryStream.ToArray();
                    await SendViaWebSocketAsync(imageBytes);
                }
            }
        }
    }

    private static Task SendViaWebSocketAsync(byte[] data)
    {
        // Simulated WebSocket send - replace with real WebSocket logic as needed
        Console.WriteLine($"Sending {data.Length} bytes via WebSocket.");
        return Task.CompletedTask;
    }
}