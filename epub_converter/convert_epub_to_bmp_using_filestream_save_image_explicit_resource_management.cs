// Convert EPUB to BMP using a FileStream to save the image file with explicit resource management.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    // Stores all created memory streams
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    // Called by the converter to obtain a stream for each page
    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Overload with page index (not used here but required by interface)
    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Called after writing is done; we simply flush the stream
    public void ReleaseStream(Stream stream)
    {
        stream?.Flush();
    }

    // Dispose all memory streams
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
            // Input EPUB file path
            string epubPath = "input.epub";
            // Desired BMP output file path
            string outputPath = "output.bmp";

            // Open the EPUB file as a read‑only stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Configure conversion to BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Provider that captures generated images in memory
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Perform the conversion; images are written to the provider's streams
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Retrieve the first generated image (first page)
                    MemoryStream resultStream = provider.Streams[0];
                    resultStream.Position = 0; // Rewind before reading

                    // Save the image to a file using an explicit FileStream
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        resultStream.CopyTo(fileStream);
                    }
                }
            }

            Console.WriteLine("EPUB successfully converted to BMP.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}