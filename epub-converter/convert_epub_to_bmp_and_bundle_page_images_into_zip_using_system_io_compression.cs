// Convert EPUB to BMP and bundle each page image into a ZIP file using System.IO.Compression utilities.

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
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
    public static void Main()
    {
        try
        {
            string epubPath = "sample.epub";
            string zipPath = "output.zip";

            if (!File.Exists(epubPath))
            {
                // Create a minimal placeholder EPUB file
                using (var fs = File.Create(epubPath))
                {
                    // Empty file; real conversion may fail but serves as example input
                }
            }

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    using (FileStream zipFile = File.Open(zipPath, FileMode.Create))
                    using (var archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                    {
                        int index = 0;
                        foreach (var ms in provider.Streams)
                        {
                            ms.Position = 0;
                            var entry = archive.CreateEntry($"page{index}.bmp");
                            using (var entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
                            index++;
                        }
                    }
                }
            }

            Console.WriteLine("Conversion completed. ZIP created at " + zipPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}