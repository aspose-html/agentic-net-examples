// Convert EPUB to BMP and bundle each page image into a ZIP file using System.IO.Compression utilities.

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
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
        // No action needed; streams are kept for later use.
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
            // Input EPUB file path
            string epubPath = "sample.epub";
            // Output ZIP file path
            string zipPath = "output.zip";

            // Ensure the input file exists (create a placeholder if not)
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // minimal ZIP header as placeholder
            }

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options for BMP format
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Create custom stream provider to capture each page as a MemoryStream
                using (var provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to BMP images using the provider
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    // Create ZIP archive and add each generated BMP image
                    using (var zipFile = new FileStream(zipPath, FileMode.Create))
                    using (var archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                    {
                        int pageIndex = 1;
                        foreach (var memoryStream in provider.Streams)
                        {
                            memoryStream.Position = 0;
                            var entry = archive.CreateEntry($"page{pageIndex}.bmp", CompressionLevel.Optimal);
                            using (var entryStream = entry.Open())
                            {
                                memoryStream.CopyTo(entryStream);
                            }
                            pageIndex++;
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