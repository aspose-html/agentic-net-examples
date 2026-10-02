// Convert EPUB to JPEG and compress all generated images into a single ZIP archive for distribution.

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
        // No action needed
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
            string inputPath = "sample.epub";
            string zipPath = "output_images.zip";

            if (!File.Exists(inputPath))
            {
                // Create a minimal placeholder EPUB file
                using (var fs = File.Create(inputPath))
                {
                    // Placeholder content (empty file)
                }
            }

            using (var epubStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    using (var zipFile = File.Open(zipPath, FileMode.Create))
                    using (var archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                    {
                        int index = 0;
                        foreach (var ms in provider.Streams)
                        {
                            ms.Position = 0;
                            var entry = archive.CreateEntry($"page_{index}.jpg");
                            using (var entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
                            index++;
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion and ZIP creation completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}