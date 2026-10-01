// Convert EPUB to PNG and create a ZIP package containing every page image for easy download.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;

public class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string zipPath = "output.zip";

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                // Default format is PNG; explicitly set if desired
                options.Format = ImageFormat.Png;

                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    using (FileStream zipFile = File.Create(zipPath))
                    {
                        using (ZipArchive zip = new ZipArchive(zipFile, ZipArchiveMode.Create))
                        {
                            for (int i = 0; i < provider.Streams.Count; i++)
                            {
                                MemoryStream ms = provider.Streams[i];
                                ms.Position = 0;
                                string entryName = $"page_{i + 1}.png";
                                ZipArchiveEntry entry = zip.CreateEntry(entryName);
                                using (Stream entryStream = entry.Open())
                                {
                                    ms.CopyTo(entryStream);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion completed. ZIP created at: " + zipPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}