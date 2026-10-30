// Export an EPUB chapter to PNG, ensuring each page is saved as a separate image file.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

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
        // No action needed; streams are kept for later use.
        if (stream != null && stream.CanWrite)
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
            // Input EPUB file (ensure this file exists in the working directory)
            string epubPath = "sample.epub";
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options (PNG is default format)
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Create custom stream provider to capture each page as a separate stream
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to images, each page will be written to a stream from the provider
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    // Save each generated page stream to a separate PNG file
                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        MemoryStream pageStream = provider.Streams[i];
                        pageStream.Position = 0; // Rewind before reading

                        string outputFile = $"page_{i + 1}.png";
                        using (FileStream fileStream = File.Create(outputFile))
                        {
                            pageStream.CopyTo(fileStream);
                        }

                        Console.WriteLine($"Saved page {i + 1} to '{outputFile}'.");
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