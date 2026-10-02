// Render an EPUB book to a series of PNG images, one per chapter, for visual preview.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

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

public class Program
{
    public static void Main()
    {
        try
        {
            string epubPath = "sample.epub";
            string outputDir = "output";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    int index = 1;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outPath = Path.Combine(outputDir, $"chapter_{index}.png");
                        using (FileStream fileStream = File.Create(outPath))
                        {
                            ms.CopyTo(fileStream);
                        }
                        index++;
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