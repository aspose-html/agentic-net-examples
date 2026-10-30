// Export every page of an EPUB as individual BMP images using ImageSaveOptions to control per‑page rendering.

using System;
using System.Collections.Generic;
using System.IO;

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
    static void Main()
    {
        try
        {
            string epubPath = "sample.epub";

            if (!File.Exists(epubPath))
            {
                // Create an empty placeholder EPUB file to avoid file-not-found errors.
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                int pageIndex = 0;
                foreach (var ms in provider.Streams)
                {
                    ms.Position = 0;
                    string outputFile = $"page_{pageIndex}.bmp";
                    using (FileStream fileStream = File.Create(outputFile))
                    {
                        ms.CopyTo(fileStream);
                    }
                    Console.WriteLine($"Saved {outputFile}");
                    pageIndex++;
                }

                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}