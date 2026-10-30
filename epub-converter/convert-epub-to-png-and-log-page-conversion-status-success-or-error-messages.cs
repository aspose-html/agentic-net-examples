// Convert EPUB to PNG and log each page conversion status, including success or error messages.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();

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
            string inputPath = "sample.epub";
            string outputDir = "output";

            Directory.CreateDirectory(outputDir);

            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    int pageIndex = 0;
                    foreach (var ms in provider.Streams)
                    {
                        try
                        {
                            ms.Position = 0;
                            string outPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                            using (FileStream file = File.Create(outPath))
                            {
                                ms.CopyTo(file);
                            }
                            Console.WriteLine($"Page {pageIndex} converted successfully: {outPath}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error saving page {pageIndex}: {ex.Message}");
                        }
                        pageIndex++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}