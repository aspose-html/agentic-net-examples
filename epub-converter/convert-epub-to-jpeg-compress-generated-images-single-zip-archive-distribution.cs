// Convert EPUB to JPEG and compress all generated images into a single ZIP archive for distribution.

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

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
        // No action needed; streams will be used after conversion.
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.epub";
            string zipPath = "output_images.zip";

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    using (FileStream zipFileStream = File.Create(zipPath))
                    {
                        using (ZipArchive zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
                        {
                            int index = 1;
                            foreach (MemoryStream ms in provider.Streams)
                            {
                                ms.Position = 0;
                                ZipArchiveEntry entry = zipArchive.CreateEntry($"page{index}.jpg");
                                using (Stream entryStream = entry.Open())
                                {
                                    ms.CopyTo(entryStream);
                                }
                                index++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion to JPEG completed and images zipped successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}