// Implement ICreateStreamProvider to supply file streams for multi‑page HTML to JPEG conversion.

using System;
using System.IO;
using System.Collections.Generic;

sealed class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Page 1</h1></body></html>");
            }

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            var provider = new MemoryStreamProvider();

            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
            }

            for (int i = 0; i < provider.Streams.Count; i++)
            {
                var ms = provider.Streams[i];
                ms.Position = 0;
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"output_page_{i + 1}.jpg");
                using (var fileStream = File.Create(outputPath))
                {
                    ms.CopyTo(fileStream);
                }
                Console.WriteLine($"Saved page {i + 1} to {outputPath}");
            }

            provider.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}