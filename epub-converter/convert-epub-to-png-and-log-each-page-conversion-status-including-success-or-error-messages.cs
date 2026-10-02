// Convert EPUB to PNG and log each page conversion status, including success or error messages.

using System;
using System.IO;
using System.Collections.Generic;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider
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
            string dataDir = "Data";
            string outputDir = "Output";

            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            if (!File.Exists(epubPath))
            {
                // Create a minimal placeholder EPUB file.
                File.WriteAllBytes(epubPath, new byte[0]);
                Console.WriteLine($"Created placeholder EPUB at '{epubPath}'.");
            }

            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions();
                // Set desired resolution if needed
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                int pageIndex = 1;
                foreach (var memoryStream in provider.Streams)
                {
                    try
                    {
                        memoryStream.Position = 0;
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            memoryStream.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Page {pageIndex}: Successfully saved to '{outputPath}'.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Page {pageIndex}: Error saving PNG - {ex.Message}");
                    }
                    pageIndex++;
                }

                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}