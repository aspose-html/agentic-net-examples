// Store extracted images in memory streams for further processing before writing to disk.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.IO;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
        }
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
            // Path to the source EPUB file
            string epubPath = "input.epub";
            // Path where the first extracted image will be saved
            string outputPath = "output.png";

            // Open the EPUB file as a stream
            Stream epubStream = File.OpenRead(epubPath);

            // Create image save options (default format)
            ImageSaveOptions options = new ImageSaveOptions();

            // Initialize the custom stream provider to capture output in memory
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Convert EPUB to images, output will be written to the provider's streams
                Converter.ConvertEPUB(epubStream, options, provider);

                // Retrieve the first generated image stream
                MemoryStream resultStream = provider.Streams[0];
                resultStream.Position = 0;

                // Write the image to disk
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    resultStream.CopyTo(fileStream);
                }

                // Example: further processing of the image bytes in memory
                byte[] imageBytes = resultStream.ToArray();
                // (imageBytes can now be used for additional processing)
            }

            epubStream.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}