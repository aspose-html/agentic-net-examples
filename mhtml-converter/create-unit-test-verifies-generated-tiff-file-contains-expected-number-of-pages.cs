// Create a unit test that verifies the generated TIFF file contains the expected number of pages.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
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
        // No action needed; streams are retained for later inspection.
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
            // Prepare temporary working directory
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlTiffTest");
            Directory.CreateDirectory(tempDir);

            // Create simple HTML content
            string htmlContent = "<html><body><h1>Page 1</h1></body></html>";
            string htmlFilePath = Path.Combine(tempDir, "content.html");
            File.WriteAllText(htmlFilePath, htmlContent);

            // Create minimal EPUB package (zip) containing the HTML file
            string epubPath = Path.Combine(tempDir, "sample.epub");
            using (FileStream epubStream = new FileStream(epubPath, FileMode.Create, FileAccess.Write))
            using (ZipArchive archive = new ZipArchive(epubStream, ZipArchiveMode.Create, leaveOpen: true))
            {
                // Add mimetype file (required for EPUB, stored without compression)
                var mimetypeEntry = archive.CreateEntry("mimetype", CompressionLevel.NoCompression);
                using (var entryStream = mimetypeEntry.Open())
                using (var writer = new StreamWriter(entryStream))
                {
                    writer.Write("application/epub+zip");
                }

                // Add HTML content
                var contentEntry = archive.CreateEntry("OEBPS/content.html", CompressionLevel.Optimal);
                using (var entryStream = contentEntry.Open())
                using (var writer = new StreamWriter(entryStream))
                {
                    writer.Write(htmlContent);
                }
            }

            // Open EPUB stream
            using (Stream epubFileStream = File.OpenRead(epubPath))
            {
                // Configure TIFF save options
                Aspose.Html.Saving.ImageSaveOptions saveOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                saveOptions.UseAntialiasing = true;
                saveOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
                saveOptions.HorizontalResolution = 300;
                saveOptions.VerticalResolution = 300;

                // Create custom stream provider to capture page streams
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to multi-page TIFF using the provider
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubFileStream, saveOptions, provider);

                    // Verify the number of generated pages
                    int expectedPageCount = 1; // Based on simple single-page HTML
                    int actualPageCount = provider.Streams.Count;

                    if (actualPageCount != expectedPageCount)
                    {
                        throw new Exception($"TIFF page count verification failed. Expected: {expectedPageCount}, Actual: {actualPageCount}");
                    }

                    // Optionally, save each page stream to a file for inspection
                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        provider.Streams[i].Position = 0;
                        string pagePath = Path.Combine(tempDir, $"page_{i + 1}.tiff");
                        using (FileStream fileOut = new FileStream(pagePath, FileMode.Create, FileAccess.Write))
                        {
                            provider.Streams[i].CopyTo(fileOut);
                        }
                    }

                    Console.WriteLine("TIFF page count verification passed.");
                }
            }

            // Cleanup temporary files (optional)
            // Directory.Delete(tempDir, true);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}