// Render an EPUB book to a series of PNG images, one per chapter, for visual preview.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string path, string contentType)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string path, string contentType, int index)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        stream?.Dispose();
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms?.Dispose();
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
            string epubPath = "book.epub"; // path to the source EPUB file
            string outputFolder = "PreviewImages";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Converter.ConvertEPUB(epubStream, options, provider);

                    int index = 1;
                    foreach (var ms in provider.Streams)
                    {
                        string outputPath = Path.Combine(outputFolder, $"chapter_{index}.png");
                        File.WriteAllBytes(outputPath, ms.ToArray());
                        index++;
                    }
                }
            }

            Console.WriteLine("EPUB conversion to PNG preview images completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}