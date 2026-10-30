// Batch convert a collection of EPUB books to TIFF files using a foreach loop and default conversion settings.

using System;
using System.IO;
using System.Collections.Generic;

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
        // No action needed
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
            var epubFiles = new List<string>
            {
                "book1.epub",
                "book2.epub"
            };

            // Create placeholder EPUB files if they do not exist
            foreach (var path in epubFiles)
            {
                if (!File.Exists(path))
                {
                    File.WriteAllBytes(path, new byte[0]);
                }
            }

            int bookIndex = 1;
            foreach (var epubPath in epubFiles)
            {
                using (var inputStream = File.OpenRead(epubPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    var provider = new MemoryStreamProvider();

                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                    int pageIndex = 1;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outputFile = $"book{bookIndex}_page{pageIndex}.tiff";
                        using (var fileStream = File.Create(outputFile))
                        {
                            ms.CopyTo(fileStream);
                        }
                        pageIndex++;
                    }

                    provider.Dispose();
                }
                bookIndex++;
            }

            Console.WriteLine("EPUB to TIFF conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}