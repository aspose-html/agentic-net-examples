// Create a utility that accepts HTML string and returns a GIF byte array using ImageSaveOptions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            byte[] gifBytes = ConvertHtmlToGif(html);
            Console.WriteLine($"Generated GIF byte array length: {gifBytes.Length}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] ConvertHtmlToGif(string htmlContent)
    {
        var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
        using (var provider = new MemoryStreamProvider())
        {
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
            if (provider.Streams.Count == 0)
                throw new InvalidOperationException("No output stream was created.");

            var stream = provider.Streams[0];
            stream.Position = 0;
            return stream.ToArray();
        }
    }
}