// Convert EPUB to TIFF and produce a CSV report listing each page file name, size, and conversion time.

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.IO;
using Aspose.Html.Converters;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        // No action needed
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

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);
            string csvPath = Path.Combine(outputDir, "report.csv");

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                var options = new ImageSaveOptions(ImageFormat.Tiff)
                {
                    Compression = Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    BackgroundColor = System.Drawing.Color.White
                };
                options.PageSetup.AnyPage = new Page(
                    new Size(800, 1000),
                    new Margin(0, 0, 0, 0));

                using (var provider = new MemoryStreamProvider())
                {
                    var conversionTimer = Stopwatch.StartNew();
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);
                    conversionTimer.Stop();

                    var csvLines = new List<string>();
                    csvLines.Add("FileName,SizeBytes,ConversionTimeMs");

                    int pageIndex = 1;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string pageFile = Path.Combine(outputDir, $"page_{pageIndex}.tiff");
                        var writeTimer = Stopwatch.StartNew();
                        using (var fileStream = File.Create(pageFile))
                        {
                            ms.CopyTo(fileStream);
                        }
                        writeTimer.Stop();

                        long size = new FileInfo(pageFile).Length;
                        long timeMs = writeTimer.ElapsedMilliseconds;
                        csvLines.Add($"{Path.GetFileName(pageFile)},{size},{timeMs}");
                        pageIndex++;
                    }

                    File.WriteAllLines(csvPath, csvLines);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}