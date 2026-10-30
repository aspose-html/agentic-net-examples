// Convert a large EPUB to BMP by streaming input and output to minimize memory consumption during conversion.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = "input.epub";
            // Output BMP file path (first page)
            string outputPath = "output_page1.bmp";

            // Open EPUB as a read-only stream
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Configure image save options for BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Create custom stream provider to capture output streams
                MemoryStreamProvider provider = new MemoryStreamProvider();

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                // Ensure at least one output stream was generated
                if (provider.Streams.Count > 0)
                {
                    // Get the first generated memory stream (first page)
                    MemoryStream resultStream = provider.Streams[0];
                    resultStream.Position = 0;

                    // Write the BMP data to a file
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        resultStream.CopyTo(fileStream);
                    }

                    Console.WriteLine($"Conversion completed. First page saved to '{outputPath}'.");
                }
                else
                {
                    Console.WriteLine("No output streams were generated during conversion.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom stream provider implementation
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