// Convert EPUB to JPEG by writing the result directly to a FileStream within a using block.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Open the EPUB file as a read-only stream
            using (Stream epubStream = File.OpenRead("input.epub"))
            {
                // Set image save options to JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Create a custom stream provider that captures output streams in memory
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert the EPUB to images; each page will be written to a memory stream
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Write each generated image stream to a JPEG file using a FileStream
                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        MemoryStream imageStream = provider.Streams[i];
                        imageStream.Position = 0; // Reset position before copying

                        string outputPath = $"output_page_{i + 1}.jpg";
                        using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                        {
                            imageStream.CopyTo(fileStream);
                        }
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

// Custom stream provider that stores each created stream in a list
class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        MemoryStream ms = new MemoryStream();
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
        foreach (MemoryStream ms in Streams)
        {
            ms.Dispose();
        }
    }
}