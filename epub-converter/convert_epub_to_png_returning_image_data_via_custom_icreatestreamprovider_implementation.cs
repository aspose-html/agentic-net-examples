// Convert EPUB to PNG while returning the image data through a custom ICreateStreamProvider implementation.

using System;
using System.Collections.Generic;
using System.IO;

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
        // No action needed for in-memory streams in this example
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
            // Define input EPUB path and ensure it exists (create a minimal placeholder if needed)
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                // Create a minimal empty EPUB file (this is just for demonstration; real EPUB should be valid)
                using (var fs = File.Create(inputPath))
                {
                    // Write minimal ZIP header to make it a valid archive (optional)
                }
            }

            // Open the EPUB file as a stream
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Set image save options (defaults to PNG)
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();

                // Create custom stream provider to capture output images in memory
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB pages to images using the provider
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    // Ensure output directory exists
                    string outputDir = "output_images";
                    Directory.CreateDirectory(outputDir);

                    // Save each generated image stream to a separate PNG file
                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        MemoryStream imageStream = provider.Streams[i];
                        imageStream.Position = 0;
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            imageStream.CopyTo(fileStream);
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion to PNG completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during EPUB to PNG conversion: " + ex.Message);
        }
    }
}