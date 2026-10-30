// Convert each page of an EPUB to separate JPEG files by specifying page range in ImageSaveOptions.

using System;
using System.IO;
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
    static void Main(string[] args)
    {
        try
        {
            string epubPath = "sample.epub";
            string outputDir = "output";

            Directory.CreateDirectory(outputDir);

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                // Example of setting page range (optional, adjust as needed)
                // options.PageSetup.FirstPage = 1;
                // options.PageSetup.LastPage = 0; // 0 means all pages

                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    int pageNumber = 1;
                    foreach (MemoryStream ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outputPath = Path.Combine(outputDir, $"page_{pageNumber}.jpg");
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            ms.CopyTo(fileStream);
                        }
                        pageNumber++;
                    }
                }
            }

            Console.WriteLine("EPUB conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}