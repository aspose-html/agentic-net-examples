// Batch process multiple EPUB files to PNG images by programmatically invoking Converter.ConvertEPUB for each entry.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;

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
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "InputEpubs");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "OutputImages");

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Example: process all .epub files in the input directory
            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub");
            foreach (string epubPath in epubFiles)
            {
                using (FileStream epubStream = File.OpenRead(epubPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions();
                    // Default format is PNG; can be set explicitly if needed:
                    // options.ImageFormat = Aspose.Html.Rendering.Image.ImageFormat.Png;

                    using (var provider = new MemoryStreamProvider())
                    {
                        Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                        string baseFileName = Path.GetFileNameWithoutExtension(epubPath);
                        int pageIndex = 0;
                        foreach (var memoryStream in provider.Streams)
                        {
                            memoryStream.Position = 0;
                            string outputPath = Path.Combine(outputDir, $"{baseFileName}_page{pageIndex}.png");
                            using (FileStream fileStream = File.Create(outputPath))
                            {
                                memoryStream.CopyTo(fileStream);
                            }
                            pageIndex++;
                        }
                    }
                }
            }

            Console.WriteLine("EPUB to PNG conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}