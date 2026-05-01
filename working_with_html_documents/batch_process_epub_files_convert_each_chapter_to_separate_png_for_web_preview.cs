// Batch process EPUB files, converting each chapter to a separate PNG for web preview.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    // Stores all created memory streams (one per page)
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    // Called by the converter to obtain a stream for a page (no index)
    public Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    // Called by the converter to obtain a stream for a page (with index)
    public Stream GetStream(string name, string extension, int index)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    // Called after writing is finished; we do not need special handling
    public void ReleaseStream(Stream stream)
    {
        // No action required
    }

    // Exposes the collected streams for saving to files
    public IReadOnlyList<MemoryStream> Streams => _streams;

    // Dispose all memory streams
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
            // Directory containing EPUB files
            string inputDir = @"C:\Epubs";
            // Directory where PNG previews will be saved
            string outputDir = @"C:\EpubPreviews";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each EPUB file in the input directory
            foreach (string epubPath in Directory.GetFiles(inputDir, "*.epub"))
            {
                // Open the EPUB file as a read‑only stream
                using (FileStream epubStream = File.OpenRead(epubPath))
                {
                    // Default image save options (PNG format)
                    ImageSaveOptions options = new ImageSaveOptions();

                    // Provider that will capture each generated page as a memory stream
                    using (MemoryStreamProvider provider = new MemoryStreamProvider())
                    {
                        // Convert the EPUB; each page is written to a separate stream in the provider
                        Converter.ConvertEPUB(epubStream, options, provider);

                        // Save each page stream to an individual PNG file
                        int pageIndex = 0;
                        foreach (MemoryStream pageStream in provider.Streams)
                        {
                            // Reset position before reading
                            pageStream.Position = 0;

                            string fileName = $"{Path.GetFileNameWithoutExtension(epubPath)}_page_{pageIndex}.png";
                            string outputPath = Path.Combine(outputDir, fileName);

                            // Write the PNG data to disk
                            using (FileStream fileStream = File.Create(outputPath))
                            {
                                pageStream.CopyTo(fileStream);
                            }

                            pageIndex++;
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