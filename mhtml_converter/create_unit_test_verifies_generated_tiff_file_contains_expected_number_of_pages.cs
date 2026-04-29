// Create a unit test that verifies the generated TIFF file contains the expected number of pages.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string fileName, string mimeType)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string fileName, string mimeType, int pageNumber)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No additional handling required.
    }

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
            // Path to the source EPUB file.
            string epubPath = "sample.epub";

            // Open the EPUB file as a stream.
            using Stream epubStream = File.OpenRead(epubPath);

            // Configure image save options for TIFF format.
            var options = new ImageSaveOptions(ImageFormat.Tiff);

            // Create a custom stream provider to capture each page as a separate stream.
            using var provider = new MemoryStreamProvider();

            // Convert EPUB to TIFF images, each page will be written to a separate stream.
            Converter.ConvertEPUB(epubStream, options, provider);

            // Verify the number of generated pages.
            int actualPageCount = provider.Streams.Count;
            int expectedPageCount = 3; // Adjust this value based on the known EPUB content.

            if (actualPageCount != expectedPageCount)
                throw new Exception($"Page count mismatch. Expected {expectedPageCount}, but got {actualPageCount}.");

            // Optionally, save each page stream to a physical TIFF file for manual inspection.
            for (int i = 0; i < provider.Streams.Count; i++)
            {
                provider.Streams[i].Position = 0;
                string outputPath = $"page_{i + 1}.tiff";
                File.WriteAllBytes(outputPath, provider.Streams[i].ToArray());
            }

            Console.WriteLine($"TIFF conversion produced the expected number of pages: {actualPageCount}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}