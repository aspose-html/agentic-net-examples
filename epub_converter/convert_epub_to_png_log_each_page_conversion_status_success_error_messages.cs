// Convert EPUB to PNG and log each page conversion status, including success or error messages.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    // Called by Aspose.HTML to obtain a stream for each output page.
    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    // Overload with page number (used for multi‑page output).
    public Stream GetStream(string name, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    // Called after writing is finished; no special handling needed.
    public void ReleaseStream(Stream stream) { }

    // Dispose all created memory streams.
    public void Dispose()
    {
        foreach (var ms in _streams)
            ms.Dispose();
    }

    // Expose the collected streams for saving to files.
    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        // Paths – adjust as needed.
        string epubPath = "sample.epub";
        string outputDir = "output_images";

        // Ensure output directory exists.
        Directory.CreateDirectory(outputDir);

        // Prepare conversion options (default PNG settings).
        ImageSaveOptions options = new ImageSaveOptions();

        // Provider that captures each generated page as a MemoryStream.
        using (var provider = new MemoryStreamProvider())
        {
            try
            {
                // Open the EPUB file as a readable stream.
                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    // Perform the conversion; each page is written to a stream from the provider.
                    Converter.ConvertEPUB(epubStream, options, provider);
                }

                // Save each page stream to a separate PNG file and log the result.
                int pageIndex = 1;
                foreach (var ms in provider.Streams)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.png");
                    try
                    {
                        // Write the in‑memory PNG data to disk.
                        File.WriteAllBytes(outputPath, ms.ToArray());
                        Console.WriteLine($"Page {pageIndex}: conversion succeeded, saved to '{outputPath}'.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Page {pageIndex}: error saving file – {ex.Message}");
                    }
                    pageIndex++;
                }
            }
            catch (Exception ex)
            {
                // Log any conversion‑level errors.
                Console.WriteLine($"Conversion failed: {ex.Message}");
            }
        }
    }
}