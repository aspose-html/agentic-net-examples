// Implement a custom stream provider that compresses JPEG pages using GZip before saving to disk.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        // No disposal here; streams are kept for later use.
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputZipPath = "output.zip";

            // Ensure a sample EPUB file exists (empty placeholder for demonstration)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream inputStream = File.OpenRead(inputPath))
            {
                var options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                    using (var zip = new ZipArchive(File.Open(outputZipPath, FileMode.Create), ZipArchiveMode.Create))
                    {
                        for (int i = 0; i < provider.Streams.Count; i++)
                        {
                            var memoryStream = provider.Streams[i];
                            memoryStream.Position = 0;

                            var entry = zip.CreateEntry($"page{i + 1}.jpg.gz");
                            using (var entryStream = entry.Open())
                            using (var gzip = new GZipStream(entryStream, CompressionMode.Compress))
                            {
                                memoryStream.CopyTo(gzip);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Conversion and compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}