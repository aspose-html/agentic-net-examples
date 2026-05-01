// Export an EPUB chapter to PNG, ensuring each page is saved as a separate image file.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string outputPath, string mimeType)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string outputPath, string mimeType, int pageNumber)
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
            // Path to the source EPUB file.
            string epubPath = "sample.epub";

            // Directory where PNG images will be saved.
            string outputDir = "output_images";
            Directory.CreateDirectory(outputDir);

            // Open the EPUB file as a stream.
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Set default image save options (PNG format by default).
                ImageSaveOptions options = new ImageSaveOptions();

                // Create the custom stream provider to capture each page image.
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert the EPUB to PNG images, one per page.
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Save each generated page stream to a separate PNG file.
                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            provider.Streams[i].WriteTo(fileStream);
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