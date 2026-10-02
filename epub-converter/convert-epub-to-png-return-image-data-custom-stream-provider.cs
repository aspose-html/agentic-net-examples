// Convert EPUB to PNG while returning the image data through a custom ICreateStreamProvider implementation.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private List<MemoryStream> _streams = new List<MemoryStream>();
    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
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
        foreach (var s in _streams)
        {
            s.Dispose();
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
            string epubPath = "sample.epub";
            if (!File.Exists(epubPath))
            {
                Console.WriteLine($"Input EPUB file not found: {epubPath}");
                return;
            }

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(); // defaults to PNG
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    int index = 0;
                    foreach (MemoryStream ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outputPath = $"page_{index}.png";
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            ms.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Saved page {index} to {outputPath}");
                        index++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}