// Implement a custom stream provider that compresses JPEG pages using GZip before saving to disk.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

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
        // No action needed; streams are retained for later use.
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
            // Input EPUB file (create a minimal sample if it does not exist)
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                // Create an empty EPUB file as placeholder
                using (var fs = File.Create(inputPath)) { }
            }

            // Output ZIP file
            string outputZipPath = "compressed_images.zip";

            // Open input stream
            using (Stream inputStream = File.OpenRead(inputPath))
            {
                // Set image save options to JPEG
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Create custom stream provider
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB pages to JPEG streams
                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                    // Create ZIP archive for compressed images
                    using (FileStream zipFileStream = File.Create(outputZipPath))
                    using (ZipArchive zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
                    {
                        int index = 0;
                        foreach (MemoryStream imageStream in provider.Streams)
                        {
                            imageStream.Position = 0;

                            // Compress JPEG data using GZip
                            using (MemoryStream compressedStream = new MemoryStream())
                            {
                                using (GZipStream gzip = new GZipStream(compressedStream, CompressionLevel.Optimal, leaveOpen: true))
                                {
                                    imageStream.CopyTo(gzip);
                                }
                                compressedStream.Position = 0;

                                // Add compressed entry to ZIP archive
                                string entryName = $"page{index}.jpg.gz";
                                ZipArchiveEntry entry = zipArchive.CreateEntry(entryName, CompressionLevel.NoCompression);
                                using (Stream entryStream = entry.Open())
                                {
                                    compressedStream.CopyTo(entryStream);
                                }
                            }

                            index++;
                        }
                    }
                }
            }

            Console.WriteLine("JPEG pages have been converted, compressed with GZip, and saved to the ZIP archive successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}