// Convert EPUB to TIFF by opening a FileStream and passing it to Converter.ConvertEPUB with options.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

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

    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputDir = "output";

            // Ensure input file exists (placeholder if missing)
            if (!File.Exists(inputPath))
            {
                using (var fs = File.Create(inputPath))
                {
                    // Write minimal placeholder content
                    byte[] placeholder = new byte[] { 0x50, 0x4B, 0x03, 0x04 }; // ZIP header (EPUB is a zip)
                    fs.Write(placeholder, 0, placeholder.Length);
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        MemoryStream ms = provider.Streams[i];
                        ms.Position = 0;
                        string outPath = Path.Combine(outputDir, $"page_{i + 1}.tiff");
                        using (FileStream fileStream = File.Create(outPath))
                        {
                            ms.CopyTo(fileStream);
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion to TIFF completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}