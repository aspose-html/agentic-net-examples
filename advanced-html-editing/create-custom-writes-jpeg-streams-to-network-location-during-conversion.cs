// Create a custom ICreateStreamProvider that writes JPEG streams to a network location during conversion.

using System;
using System.Collections.Generic;
using System.IO;

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
    static void Main()
    {
        try
        {
            string epubPath = "sample.epub";
            if (!File.Exists(epubPath))
            {
                // Create a minimal placeholder EPUB file.
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using Stream inputStream = File.OpenRead(epubPath);
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            using var provider = new MemoryStreamProvider();

            Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

            string networkFolder = @"\\networkshare\output";
            Directory.CreateDirectory(networkFolder);

            for (int i = 0; i < provider.Streams.Count; i++)
            {
                var ms = provider.Streams[i];
                ms.Position = 0;
                string outputPath = Path.Combine(networkFolder, $"page_{i + 1}.jpg");
                using var fileStream = File.Create(outputPath);
                ms.CopyTo(fileStream);
            }

            Console.WriteLine("Conversion completed. JPEG files saved to network location.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}