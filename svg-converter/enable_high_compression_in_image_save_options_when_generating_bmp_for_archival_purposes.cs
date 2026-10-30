// Enable high compression in ImageSaveOptions when generating BMP for archival purposes.

using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.IO.Compression;

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
        // No action needed for in-memory streams
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
            // Convert SVG to BMP with custom options
            string svgCode = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            string svgOutputPath = "svg_output.bmp";
            var svgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            svgOptions.UseAntialiasing = true;
            svgOptions.HorizontalResolution = 400;
            svgOptions.VerticalResolution = 400;
            svgOptions.BackgroundColor = Color.AliceBlue;
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, ".", svgOptions, svgOutputPath);
            Console.WriteLine($"SVG converted to {svgOutputPath}");

            // Convert Markdown to HTMLDocument and then to BMP
            string markdown = "# Hello World\nThis is a **markdown** test.";
            var htmlDocument = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);
            string markdownOutputPath = "markdown_output.bmp";
            var mdOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            mdOptions.BackgroundColor = Color.AliceBlue;
            Aspose.Html.Converters.Converter.ConvertHTML(htmlDocument, mdOptions, markdownOutputPath);
            Console.WriteLine($"Markdown converted to {markdownOutputPath}");

            // Convert EPUB stream to BMP images using a custom stream provider and zip the results
            byte[] epubData = new byte[] { 0x50, 0x4B, 0x03, 0x04 }; // minimal ZIP header as placeholder
            using (var epubStream = new MemoryStream(epubData))
            {
                var epubOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                var provider = new MemoryStreamProvider();
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, epubOptions, provider);

                string zipPath = "epub_images.zip";
                using (var zipFile = new FileStream(zipPath, FileMode.Create))
                using (var archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                {
                    int index = 0;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        var entry = archive.CreateEntry($"page_{index}.bmp");
                        using (var entryStream = entry.Open())
                        {
                            ms.CopyTo(entryStream);
                        }
                        index++;
                    }
                }
                Console.WriteLine($"EPUB images zipped to {zipPath}");
                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}