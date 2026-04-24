// Convert EPUB to GIF and stream the animated result through an HttpResponse for immediate client consumption.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string suggestedFileName, string mimeType)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string suggestedFileName, string mimeType, int index)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are retained for later use.
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
    static async Task Main()
    {
        try
        {
            const string epubUrl = "https://example.com/sample.epub";

            // Download EPUB into memory
            using var httpClient = new HttpClient();
            await using var epubNetworkStream = await httpClient.GetStreamAsync(epubUrl);
            var epubMemory = new MemoryStream();
            await epubNetworkStream.CopyToAsync(epubMemory);
            epubMemory.Position = 0;

            // Prepare conversion options for GIF
            var options = new ImageSaveOptions(ImageFormat.Gif);

            // Custom provider to capture output streams
            using var provider = new MemoryStreamProvider();

            // Convert EPUB to GIF (animated if multiple pages)
            Converter.ConvertEPUB(epubMemory, options, provider);

            if (provider.Streams.Count == 0)
                throw new InvalidOperationException("No output streams were generated.");

            var resultStream = provider.Streams[0];
            resultStream.Position = 0;

            // Simple HTTP listener to stream the GIF to the client
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:5000/");
            listener.Start();
            Console.WriteLine("Listening on http://localhost:5000/ ...");

            while (true)
            {
                var context = await listener.GetContextAsync();
                var response = context.Response;
                response.ContentType = "image/gif";
                response.ContentLength64 = resultStream.Length;

                // Write GIF bytes to response
                await resultStream.CopyToAsync(response.OutputStream);
                response.OutputStream.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}