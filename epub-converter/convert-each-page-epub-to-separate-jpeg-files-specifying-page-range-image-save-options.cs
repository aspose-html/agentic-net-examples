// Convert each page of an EPUB to separate JPEG files by specifying page range in ImageSaveOptions.

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
            // Input EPUB file (ensure this file exists or create a minimal one)
            string epubPath = "sample.epub";
            if (!File.Exists(epubPath))
            {
                // Create a minimal empty EPUB file for demonstration purposes
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options for JPEG
                ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.UseAntialiasing = true;
                options.BackgroundColor = System.Drawing.Color.White;

                // Create custom stream provider to capture each page as a separate stream
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to JPEG streams (one per page)
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    // Save each generated stream to a separate JPEG file
                    int pageIndex = 1;
                    foreach (var memoryStream in provider.Streams)
                    {
                        memoryStream.Position = 0;
                        string outputFile = $"page_{pageIndex}.jpg";
                        using (FileStream fileStream = File.Create(outputFile))
                        {
                            memoryStream.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Saved {outputFile}");
                        pageIndex++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}