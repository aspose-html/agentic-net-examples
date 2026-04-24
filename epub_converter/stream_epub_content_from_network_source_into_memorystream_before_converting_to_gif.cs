// Stream EPUB content from a network source into a MemoryStream before converting it to a GIF.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

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
        {
            ms.Dispose();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string epubUrl = "https://example.com/sample.epub";
            using var httpClient = new HttpClient();
            using var networkStream = httpClient.GetStreamAsync(epubUrl).GetAwaiter().GetResult();
            var epubMemory = new MemoryStream();
            networkStream.CopyTo(epubMemory);
            epubMemory.Position = 0;

            var options = new ImageSaveOptions(ImageFormat.Gif);
            using var provider = new MemoryStreamProvider();

            Converter.ConvertEPUB(epubMemory, options, provider);

            var gifStream = provider.Streams[0];
            gifStream.Position = 0;
            using var fileStream = File.Create("output.gif");
            gifStream.CopyTo(fileStream);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}