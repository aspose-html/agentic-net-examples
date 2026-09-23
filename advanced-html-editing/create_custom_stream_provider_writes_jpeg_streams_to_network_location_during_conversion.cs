// Create a custom ICreateStreamProvider that writes JPEG streams to a network location during conversion.

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
            string html = "<html><body><h1>Hello World</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "http://example.com/");

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                string networkFolder = @"\\networkshare\output";
                Directory.CreateDirectory(networkFolder);
                int index = 1;
                foreach (var ms in provider.Streams)
                {
                    ms.Position = 0;
                    string filePath = Path.Combine(networkFolder, $"page_{index}.jpg");
                    using (var file = File.Create(filePath))
                    {
                        ms.CopyTo(file);
                    }
                    index++;
                }
            }

            Console.WriteLine("Conversion completed and images saved to network location.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}