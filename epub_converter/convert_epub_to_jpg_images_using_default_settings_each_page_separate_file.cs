// Convert an EPUB file to JPG images using default settings, saving each page as a separate file.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();
    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string path, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string path, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No additional handling required.
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
            ms.Dispose();
        _streams.Clear();
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string epubPath = "input.epub"; // Path to the source EPUB file
            string outputDir = "output_images";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Converter.ConvertEPUB(epubStream, options, provider);

                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.jpg");
                        using (FileStream file = File.Create(outputPath))
                        {
                            provider.Streams[i].Position = 0;
                            provider.Streams[i].CopyTo(file);
                        }
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