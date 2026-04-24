// Convert EPUB to JPEG and compress all generated images into a single ZIP archive for distribution.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string fileName, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string fileName, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are managed in the list.
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
        Streams.Clear();
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string epubPath = "sample.epub"; // Path to the source EPUB file
            string zipPath = "output_images.zip"; // Path for the resulting ZIP archive

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                using (var provider = new MemoryStreamProvider())
                {
                    Converter.ConvertEPUB(epubStream, options, provider);

                    using (FileStream zipFile = new FileStream(zipPath, FileMode.Create))
                    using (ZipArchive zip = new ZipArchive(zipFile, ZipArchiveMode.Create))
                    {
                        for (int i = 0; i < provider.Streams.Count; i++)
                        {
                            MemoryStream ms = provider.Streams[i];
                            ms.Position = 0;
                            string entryName = $"page{i + 1}.jpg";
                            ZipArchiveEntry entry = zip.CreateEntry(entryName, CompressionLevel.Optimal);
                            using (Stream entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion to JPEG images completed and zipped successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}