// Convert EPUB to PNG and create a ZIP package containing every page image for easy download.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using Aspose.Html.IO;
using Aspose.Html.Saving;
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

            // Ensure a sample EPUB file exists (minimal placeholder)
            if (!File.Exists(inputPath))
            {
                using (var fs = File.Create(inputPath))
                {
                    // Write minimal content; real EPUB not required for example
                    byte[] placeholder = new byte[] { 0x50, 0x4B, 0x03, 0x04 }; // ZIP header
                    fs.Write(placeholder, 0, placeholder.Length);
                }
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    using (FileStream zipFile = File.Create(outputZipPath))
                    using (ZipArchive archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                    {
                        int index = 0;
                        foreach (var ms in provider.Streams)
                        {
                            ms.Position = 0;
                            var entry = archive.CreateEntry($"page_{index}.png");
                            using (var entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
                            index++;
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion completed. ZIP created at: " + Path.GetFullPath(outputZipPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}