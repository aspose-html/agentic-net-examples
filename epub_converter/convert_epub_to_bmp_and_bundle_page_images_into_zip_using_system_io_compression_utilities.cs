// Convert EPUB to BMP and bundle each page image into a ZIP file using System.IO.Compression utilities.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

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
        // No action needed; streams are managed internally.
    }

    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();

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
    static void Main(string[] args)
    {
        try
        {
            string epubPath = "sample.epub"; // replace with your EPUB file path
            string zipPath = "output_images.zip";

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                var options = new ImageSaveOptions(ImageFormat.Bmp);
                using (var provider = new MemoryStreamProvider())
                {
                    Converter.ConvertEPUB(epubStream, options, provider);

                    using (FileStream zipFile = new FileStream(zipPath, FileMode.Create))
                    using (var archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                    {
                        int index = 1;
                        foreach (var memoryStream in provider.Streams)
                        {
                            memoryStream.Position = 0;
                            var entry = archive.CreateEntry($"page{index}.bmp", CompressionLevel.Optimal);
                            using (var entryStream = entry.Open())
                            {
                                memoryStream.CopyTo(entryStream);
                            }
                            index++;
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion to BMP images and ZIP packaging completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}