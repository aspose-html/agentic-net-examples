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
            string inputPath = "sample.epub";
            string outputZipPath = "output.zip";

            // Ensure input file exists (create a minimal placeholder if not)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // minimal zip header
            }

            using (Stream inputStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                    using (ZipArchive zip = ZipFile.Open(outputZipPath, ZipArchiveMode.Create))
                    {
                        for (int i = 0; i < provider.Streams.Count; i++)
                        {
                            MemoryStream ms = provider.Streams[i];
                            ms.Position = 0;
                            ZipArchiveEntry entry = zip.CreateEntry($"page_{i + 1}.jpg");
                            using (Stream entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion and ZIP packaging completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}