// Convert EPUB to JPEG and write the resulting image directly to an HttpResponse output stream.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();

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
        // No action needed for in-memory streams
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
            // Input EPUB file path (sample file will be created if not exists)
            string epubPath = "sample.epub";
            if (!File.Exists(epubPath))
            {
                // Create a minimal empty EPUB file for demonstration purposes
                File.WriteAllBytes(epubPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // ZIP header
            }

            // Output JPEG file path (simulating HttpResponse output stream)
            string outputPath = "output.jpg";

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    if (provider.Streams.Count > 0)
                    {
                        MemoryStream resultStream = provider.Streams[0];
                        resultStream.Position = 0;
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            resultStream.CopyTo(fileStream);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No image streams were generated.");
                    }
                }
            }

            Console.WriteLine("EPUB conversion completed. Image saved to: " + Path.GetFullPath("output.jpg"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}