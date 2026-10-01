// Convert EPUB to TIFF and archive all output files into a ZIP container to simplify file management.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using System.Drawing;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<(string Name, MemoryStream Stream)> _streams = new List<(string, MemoryStream)>();
    public IReadOnlyList<(string Name, MemoryStream Stream)> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add((name + extension, ms));
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add((name + "_" + page + extension, ms));
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed
    }

    public void Dispose()
    {
        foreach (var (_, stream) in _streams)
        {
            stream.Dispose();
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
            string inputPath = "sample.epub";
            string zipPath = "output.zip";

            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    BackgroundColor = Color.White
                };

                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                using (var zipFile = File.Create(zipPath))
                using (var archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                {
                    foreach (var entryInfo in provider.Streams)
                    {
                        entryInfo.Stream.Position = 0;
                        var zipEntry = archive.CreateEntry(entryInfo.Name);
                        using (var entryStream = zipEntry.Open())
                        {
                            entryInfo.Stream.CopyTo(entryStream);
                        }
                    }
                }

                provider.Dispose();
            }

            Console.WriteLine("Conversion and archiving completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}