// Convert EPUB to TIFF and produce a CSV report listing each page file name, size, and conversion time.

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
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
        foreach (var s in _streams)
        {
            s.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDir = "Output";
            string csvPath = Path.Combine(outputDir, "report.csv");

            Directory.CreateDirectory(outputDir);

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    BackgroundColor = Color.White
                };

                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 1000),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                var provider = new MemoryStreamProvider();

                var start = DateTime.Now;
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);
                var end = DateTime.Now;
                double elapsedMs = (end - start).TotalMilliseconds;

                using (var csvWriter = new StreamWriter(csvPath))
                {
                    csvWriter.WriteLine("FileName,Size,ConversionTimeMs");

                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        string fileName = $"page_{i + 1}.tiff";
                        string filePath = Path.Combine(outputDir, fileName);

                        using (var fileStream = File.Create(filePath))
                        {
                            var memoryStream = provider.Streams[i];
                            memoryStream.Position = 0;
                            memoryStream.CopyTo(fileStream);
                        }

                        long fileSize = new FileInfo(filePath).Length;
                        csvWriter.WriteLine($"{fileName},{fileSize},{elapsedMs}");
                    }
                }

                provider.Dispose();
            }

            Console.WriteLine("Conversion completed. CSV report generated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}