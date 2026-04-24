// Convert each page of an EPUB to separate JPEG files by specifying page range in ImageSaveOptions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    // Stores all created memory streams (one per page)
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    // Called by Aspose when a stream without page number is needed
    public Stream GetStream(string path, string extension)
    {
        return GetStream(path, extension, 0);
    }

    // Called by Aspose when a stream for a specific page is needed
    public Stream GetStream(string path, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Called after writing is finished; no special handling required
    public void ReleaseStream(Stream stream) { }

    // Dispose all stored memory streams
    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source EPUB file
            string epubPath = "input.epub";

            // Directory where JPEG pages will be saved
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Open the EPUB file as a readable stream
            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Provider that captures each rendered page into a MemoryStream
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to images, one image per page, using the provider
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Save each captured page stream to a separate JPEG file
                    int pageIndex = 1;
                    foreach (MemoryStream ms in provider.Streams)
                    {
                        ms.Position = 0; // Reset stream position before reading
                        string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.jpg");
                        using (FileStream file = File.Create(outputPath))
                        {
                            ms.CopyTo(file);
                        }
                        pageIndex++;
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