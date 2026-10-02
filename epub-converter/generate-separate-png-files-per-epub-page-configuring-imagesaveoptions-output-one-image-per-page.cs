// Generate separate PNG files for each EPUB page by configuring ImageSaveOptions to output one image per page.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

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
        // No action needed; streams are retained for later use.
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
            // Ensure the input file exists (for demonstration, create an empty file if missing)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Configure image save options (default format is PNG)
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();

                // Create custom stream provider to capture each page as a separate stream
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to images, one stream per page
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    // Save each generated stream to a separate PNG file
                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        MemoryStream pageStream = provider.Streams[i];
                        pageStream.Position = 0; // Rewind before reading

                        string outputPath = $"page_{i + 1}.png";
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            pageStream.CopyTo(fileStream);
                        }
                    }
                }
            }

            Console.WriteLine("EPUB conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}