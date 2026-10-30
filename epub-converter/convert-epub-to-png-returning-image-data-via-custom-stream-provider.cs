// Convert EPUB to PNG while returning the image data through a custom ICreateStreamProvider implementation.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

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
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string epubPath = "sample.epub";

            // Ensure the input file exists (for demonstration, create an empty file if missing)
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            // Open the EPUB stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options for PNG format
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

                // Create the custom stream provider
                using (var provider = new MemoryStreamProvider())
                {
                    // Perform the conversion
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    // Iterate over generated image streams and save each as a PNG file
                    int index = 0;
                    foreach (var memoryStream in provider.Streams)
                    {
                        memoryStream.Position = 0;
                        string outputPath = $"page_{index}.png";
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            memoryStream.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Saved page {index} to {outputPath}");
                        index++;
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