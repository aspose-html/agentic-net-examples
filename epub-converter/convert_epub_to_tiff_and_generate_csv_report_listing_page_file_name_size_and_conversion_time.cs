// Convert EPUB to TIFF and produce a CSV report listing each page file name, size, and conversion time.

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

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
            string inputPath = "sample.epub";
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);
            string csvPath = Path.Combine(outputDir, "report.csv");

            // Ensure a sample EPUB file exists (empty placeholder)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // minimal ZIP header
            }

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
                    new Aspose.Html.Drawing.Size(800, 1200),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                var provider = new MemoryStreamProvider();

                var stopwatch = Stopwatch.StartNew();
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);
                stopwatch.Stop();

                long elapsedMs = stopwatch.ElapsedMilliseconds;

                using (var csvWriter = new StreamWriter(csvPath))
                {
                    csvWriter.WriteLine("FileName,SizeBytes,ConversionTimeMs");
                    int index = 1;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string fileName = $"page{index}.tiff";
                        string filePath = Path.Combine(outputDir, fileName);
                        using (var fileStream = File.Create(filePath))
                        {
                            ms.CopyTo(fileStream);
                        }
                        long size = ms.Length;
                        csvWriter.WriteLine($"{fileName},{size},{elapsedMs}");
                        index++;
                    }
                }

                provider.Dispose();
            }

            Console.WriteLine("Conversion completed. Report saved to " + Path.GetFullPath(csvPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}