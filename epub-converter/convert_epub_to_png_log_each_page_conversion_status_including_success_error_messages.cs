// Convert EPUB to PNG and log each page conversion status, including success or error messages.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private List<MemoryStream> _streams = new List<MemoryStream>();

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

    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDir = "output";

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    int pageIndex = 1;
                    foreach (var memoryStream in provider.Streams)
                    {
                        try
                        {
                            memoryStream.Position = 0;
                            string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                            using (var fileStream = File.Create(outputPath))
                            {
                                memoryStream.CopyTo(fileStream);
                            }
                            Console.WriteLine($"Page {pageIndex}: conversion succeeded, saved to '{outputPath}'.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Page {pageIndex}: error saving PNG - {ex.Message}");
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