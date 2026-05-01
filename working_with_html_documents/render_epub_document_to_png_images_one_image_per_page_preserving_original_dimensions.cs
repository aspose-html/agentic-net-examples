// Render an EPUB document to PNG images, one image per page, preserving original dimensions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    // Stores all created memory streams (one per page)
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    // Called by the converter to obtain a stream for a page
    public Stream GetStream(string path, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Overload with page number (required by the interface)
    public Stream GetStream(string path, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Called when a stream is no longer needed (no action required)
    public void ReleaseStream(Stream stream) { }

    // Dispose all stored streams
    public void Dispose()
    {
        foreach (var ms in Streams)
            ms.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source EPUB file
            string epubPath = "sample.epub";

            // Open the EPUB as a readable stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Default image save options (PNG format)
                ImageSaveOptions options = new ImageSaveOptions();

                // Provider that captures each page as a separate memory stream
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to PNG images, one stream per page
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Save each page stream to an individual PNG file
                    int pageIndex = 0;
                    foreach (var ms in provider.Streams)
                    {
                        string outputPath = $"page_{pageIndex}.png";
                        File.WriteAllBytes(outputPath, ms.ToArray());
                        pageIndex++;
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