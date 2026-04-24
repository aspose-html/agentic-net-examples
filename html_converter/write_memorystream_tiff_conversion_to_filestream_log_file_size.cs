// Write the MemoryStream obtained from TIFF conversion to a FileStream and log the file size.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

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

    public Stream GetStream(string name, string extension, int pageNumber)
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
            // Open the EPUB file as a stream
            using (Stream epubStream = File.OpenRead("sample.epub"))
            {
                // Set image save options to TIFF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                // Create the custom stream provider
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB pages to TIFF images using the provider
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Iterate over each generated page stream
                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        MemoryStream pageStream = provider.Streams[i];
                        pageStream.Position = 0; // Reset position before copying

                        string outputPath = $"page_{i + 1}.tiff";
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            pageStream.CopyTo(fileStream);
                            fileStream.Flush();
                            long fileSize = fileStream.Length;
                            Console.WriteLine($"Saved {outputPath} - Size: {fileSize} bytes");
                        }
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