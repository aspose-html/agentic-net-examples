// Implement a custom stream provider that compresses JPEG pages using GZip before saving to disk.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Html.IO;

public class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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

public class Program
{
    public static void Main()
    {
        try
        {
            // Sample HTML content to be rendered as JPEG images.
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            var provider = new MemoryStreamProvider();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            int index = 0;
            foreach (var ms in provider.Streams)
            {
                ms.Position = 0;
                string outputPath = $"page_{index}.jpg.gz";
                using (var fileStream = File.Create(outputPath))
                using (var gzipStream = new GZipStream(fileStream, CompressionMode.Compress))
                {
                    ms.CopyTo(gzipStream);
                }
                index++;
            }

            provider.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}