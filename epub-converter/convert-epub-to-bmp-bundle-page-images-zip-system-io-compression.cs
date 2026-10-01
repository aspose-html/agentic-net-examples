// Convert EPUB to BMP and bundle each page image into a ZIP file using System.IO.Compression utilities.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using Aspose.Html.IO;

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
            string epubPath = "sample.epub";
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (Stream inputStream = File.OpenRead(epubPath))
            using (var provider = new MemoryStreamProvider())
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                string zipPath = "output.zip";
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

            Console.WriteLine("EPUB conversion to BMP and ZIP completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}