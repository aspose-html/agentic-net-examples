// Convert EPUB to PNG while returning the image data through a custom ICreateStreamProvider implementation.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

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

    // Overload with page number (also used by some converters)
    public Stream GetStream(string path, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Called when a stream can be released; we keep it for later use
    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are retained in the list
    }

    // Dispose all stored streams
    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
        Streams.Clear();
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

            // Open the EPUB file as a read‑only stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // ImageSaveOptions defaults to PNG output
                ImageSaveOptions options = new ImageSaveOptions();

                // Create the custom provider that will capture PNG data in memory
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert the EPUB to PNG images; each page is written to a stream from the provider
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Iterate over the generated image streams
                    int pageIndex = 0;
                    foreach (var memoryStream in provider.Streams)
                    {
                        memoryStream.Position = 0; // rewind before reading

                        // Example: save each page to a file (optional)
                        string outputFile = $"page_{pageIndex}.png";
                        using (FileStream file = File.Create(outputFile))
                        {
                            memoryStream.CopyTo(file);
                        }

                        Console.WriteLine($"Page {pageIndex} PNG saved, size {memoryStream.Length} bytes.");
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