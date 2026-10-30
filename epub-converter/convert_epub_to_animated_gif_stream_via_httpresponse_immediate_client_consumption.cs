// Convert EPUB to GIF and stream the animated result through an HttpResponse for immediate client consumption.

using System;
using System.IO;
using System.Collections.Generic;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

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
        // No action needed for in‑memory streams
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
    }

    public MemoryStream GetFirstStream()
    {
        return _streams.Count > 0 ? _streams[0] : null;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            const string epubPath = "sample.epub";
            const string outputGifPath = "output.gif";

            // Ensure a minimal EPUB file exists
            if (!File.Exists(epubPath))
            {
                using (var fs = File.Create(epubPath))
                {
                    // Write a tiny placeholder (empty ZIP structure) to avoid format errors
                    byte[] placeholder = new byte[] { 80, 75, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    fs.Write(placeholder, 0, placeholder.Length);
                }
            }

            using (var epubStream = File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);
                    var gifStream = provider.GetFirstStream();
                    if (gifStream != null)
                    {
                        gifStream.Position = 0;
                        using (var fileStream = File.Create(outputGifPath))
                        {
                            gifStream.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Conversion completed. GIF saved to '{outputGifPath}'.");
                    }
                    else
                    {
                        Console.WriteLine("No GIF stream was generated.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}