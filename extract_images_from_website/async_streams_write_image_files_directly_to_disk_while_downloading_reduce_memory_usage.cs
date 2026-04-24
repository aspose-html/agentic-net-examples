// Use async streams to write image files directly to disk while downloading to reduce memory usage.

using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class FileStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly string _outputDir;
    private readonly string _baseName;
    private readonly string _extension;
    private int _counter = 0;
    private readonly List<Stream> _streams = new List<Stream>();

    public FileStreamProvider(string outputDir, string baseName, string extension)
    {
        _outputDir = outputDir;
        _baseName = baseName;
        _extension = extension.StartsWith(".") ? extension : "." + extension;
    }

    public Stream GetStream(string name, string extension)
    {
        return CreateFileStream();
    }

    public Stream GetStream(string name, string extension, int page)
    {
        return CreateFileStream();
    }

    private Stream CreateFileStream()
    {
        string filePath = Path.Combine(_outputDir, $"{_baseName}_{_counter++}{_extension}");
        var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous);
        _streams.Add(fs);
        return fs;
    }

    public void ReleaseStream(Stream stream)
    {
        stream.Flush();
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string epubUrl = "https://example.com/sample.epub";
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            using HttpClient http = new HttpClient();
            await using Stream epubStream = await http.GetStreamAsync(epubUrl);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            using var provider = new FileStreamProvider(outputDir, "page", "png");

            Converter.ConvertEPUB(epubStream, options, provider);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}