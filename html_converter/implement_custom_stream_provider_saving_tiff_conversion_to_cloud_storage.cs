// Implement a custom ICreateStreamProvider that saves TIFF conversion result to a cloud storage stream.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string fileName, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string fileName, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are managed internally.
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
            // Path to the source EPUB file
            string epubPath = "sample.epub";

            // Open the EPUB file as a stream
            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                // Set image save options to TIFF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                // Create the custom stream provider
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB pages to TIFF images using the provider
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Save each generated TIFF stream to a separate file (simulating cloud storage)
                    int pageIndex = 1;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0; // Reset stream position before reading

                        // Simulated cloud upload: write to local file named "page{index}.tiff"
                        string outputFileName = $"page{pageIndex}.tiff";
                        using (FileStream file = File.Create(outputFileName))
                        {
                            ms.CopyTo(file);
                        }

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