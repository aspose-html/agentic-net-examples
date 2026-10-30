// Generate separate PNG files for each EPUB page by configuring ImageSaveOptions to output one image per page.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        if (stream != null)
        {
            stream.Flush();
        }
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
            string inputPath = "sample.epub";
            string outputDir = "output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // If the sample EPUB does not exist, create a minimal placeholder file
            if (!File.Exists(inputPath))
            {
                // Create an empty EPUB file (not a valid EPUB, but serves as placeholder)
                using (var placeholder = File.Create(inputPath)) { }
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    int pageIndex = 1;
                    foreach (MemoryStream ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            ms.CopyTo(fileStream);
                        }
                        pageIndex++;
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