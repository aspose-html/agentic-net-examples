// Export an EPUB chapter to PNG, ensuring each page is saved as a separate image file.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;

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
        // No action needed; keep streams for later use.
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
            // Prepare input EPUB file
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");

            if (!File.Exists(epubPath))
            {
                using (var zip = new ZipArchive(File.Create(epubPath), ZipArchiveMode.Create))
                {
                    var entry = zip.CreateEntry("mimetype");
                    using (var entryStream = entry.Open())
                    using (var writer = new StreamWriter(entryStream))
                    {
                        writer.Write("application/epub+zip");
                    }
                }
            }

            // Set up image save options (default PNG)
            var options = new Aspose.Html.Saving.ImageSaveOptions();

            // Create custom stream provider
            using var provider = new MemoryStreamProvider();

            // Open EPUB stream
            using var epubStream = File.OpenRead(epubPath);

            // Convert EPUB to images using the provider
            Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

            // Save each generated image stream to a separate PNG file
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            int index = 1;
            foreach (var ms in provider.Streams)
            {
                ms.Position = 0;
                string outPath = Path.Combine(outputDir, $"page_{index}.png");
                using var fileStream = File.Create(outPath);
                ms.CopyTo(fileStream);
                index++;
            }

            Console.WriteLine($"Conversion completed. {index - 1} image(s) saved to '{outputDir}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}