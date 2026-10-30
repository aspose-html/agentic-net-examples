// Convert EPUB to PNG and create a ZIP package containing every page image for easy download.

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
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
        if (stream != null)
        {
            stream.Flush();
        }
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
            string outputZipPath = "epub_pages.zip";

            // Ensure the input file exists (create a placeholder if necessary)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    using (FileStream zipFile = File.Create(outputZipPath))
                    using (ZipArchive zip = new ZipArchive(zipFile, ZipArchiveMode.Create))
                    {
                        int pageIndex = 0;
                        foreach (MemoryStream ms in provider.Streams)
                        {
                            ms.Position = 0;
                            ZipArchiveEntry entry = zip.CreateEntry($"page_{pageIndex}.png");
                            using (Stream entryStream = entry.Open())
                            {
                                ms.CopyTo(entryStream);
                            }
                            pageIndex++;
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion completed. ZIP file created at: " + Path.GetFullPath(outputZipPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}