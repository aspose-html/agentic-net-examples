// Create individual TIFF images for every EPUB page by setting ImageSaveOptions.PageNumber during conversion.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;

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
            string inputPath = "sample.epub";
            string outputDir = "output";

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Ensure a sample EPUB exists (minimal placeholder)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]); // placeholder empty file
            }

            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
                {
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    Compression = Compression.None,
                    BackgroundColor = System.Drawing.Color.White,
                    PageSetup = { AnyPage = new Page(new Size(800, 1000), new Margin(0, 0, 0, 0)) }
                };

                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    int pageIndex = 1;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.tiff");
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            ms.CopyTo(fileStream);
                        }
                        pageIndex++;
                    }
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}