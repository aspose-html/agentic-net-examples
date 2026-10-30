// Render an EPUB book to a series of PNG images, one per chapter, for visual preview.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

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
            // Path to the EPUB file
            string epubPath = "sample.epub";

            // Verify the EPUB file exists
            if (!File.Exists(epubPath))
            {
                Console.WriteLine($"EPUB file not found at path: {epubPath}");
                return;
            }

            // Open the EPUB file stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options (PNG format by default)
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 150;
                options.VerticalResolution = 150;

                // Create a custom stream provider to capture each page as a separate PNG
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert the EPUB to images, one per chapter/page
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    // Save each generated image stream to a PNG file
                    int index = 1;
                    foreach (MemoryStream ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outputPath = $"chapter_{index}.png";
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            ms.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Saved chapter {index} preview to: {outputPath}");
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