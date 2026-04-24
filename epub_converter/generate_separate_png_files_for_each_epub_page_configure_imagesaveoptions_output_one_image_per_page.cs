// Generate separate PNG files for each EPUB page by configuring ImageSaveOptions to output one image per page.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();
    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string path, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string path, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are managed in the list.
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
            string epubPath = "input.epub";
            using var epubStream = File.OpenRead(epubPath);
            var options = new ImageSaveOptions();
            using var provider = new MemoryStreamProvider();

            Converter.ConvertEPUB(epubStream, options, provider);

            for (int i = 0; i < provider.Streams.Count; i++)
            {
                provider.Streams[i].Position = 0;
                string outputPath = $"page_{i + 1}.png";
                using var fileStream = File.Create(outputPath);
                provider.Streams[i].CopyTo(fileStream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}