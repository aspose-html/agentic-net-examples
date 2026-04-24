// Convert EPUB to TIFF and produce a CSV report listing each page file name, size, and conversion time.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<(MemoryStream Stream, DateTime Timestamp)> Streams { get; } = new List<(MemoryStream, DateTime)>();

    public Stream GetStream(string fileName, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add((ms, DateTime.UtcNow));
        return ms;
    }

    public Stream GetStream(string fileName, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        Streams.Add((ms, DateTime.UtcNow));
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        stream?.Dispose();
    }

    public void Dispose()
    {
        foreach (var (stream, _) in Streams)
        {
            stream?.Dispose();
        }
        Streams.Clear();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.epub";
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            using (FileStream epubStream = File.OpenRead(inputPath))
            using (var provider = new MemoryStreamProvider())
            {
                var options = new ImageSaveOptions(ImageFormat.Tiff);

                DateTime conversionStart = DateTime.UtcNow;
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);
                DateTime conversionEnd = DateTime.UtcNow;
                double totalMilliseconds = (conversionEnd - conversionStart).TotalMilliseconds;

                var csvBuilder = new StringBuilder();
                csvBuilder.AppendLine("FileName,SizeBytes,ConversionTimeMs");

                int pageIndex = 1;
                foreach (var (stream, timestamp) in provider.Streams)
                {
                    stream.Position = 0;
                    string fileName = $"page_{pageIndex}.tiff";
                    string filePath = Path.Combine(outputDir, fileName);
                    using (FileStream file = File.Create(filePath))
                    {
                        stream.CopyTo(file);
                    }

                    long size = stream.Length;
                    double pageTimeMs = (timestamp - conversionStart).TotalMilliseconds;
                    csvBuilder.AppendLine($"{fileName},{size},{pageTimeMs}");

                    pageIndex++;
                }

                string csvPath = Path.Combine(outputDir, "report.csv");
                File.WriteAllText(csvPath, csvBuilder.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}