// Create individual TIFF images for every EPUB page by setting ImageSaveOptions.PageNumber during conversion.

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
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output directory for TIFF pages
            string outputDir = "TiffPages";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Configure image save options for TIFF
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    BackgroundColor = System.Drawing.Color.White
                };

                // Create custom stream provider to capture each page
                using (var provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to TIFF pages using the provider
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    // Save each generated page stream to a separate TIFF file
                    int pageIndex = 1;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.tiff");
                        using (FileStream file = File.Create(outputPath))
                        {
                            ms.CopyTo(file);
                        }
                        Console.WriteLine($"Saved page {pageIndex} to {outputPath}");
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