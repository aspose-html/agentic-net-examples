// Dispose of the Converter object and any open streams after completing EPUB to GIF conversion.

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

    public System.IO.Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
    }

    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            // Create a minimal sample EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                using (var fs = File.Create(inputPath))
                {
                    // Write minimal content (empty file for demonstration)
                }
            }

            using (System.IO.FileStream epubStream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    if (provider.Streams.Count > 0)
                    {
                        var gifStream = provider.Streams[0];
                        gifStream.Position = 0;
                        using (System.IO.FileStream file = System.IO.File.Create(outputPath))
                        {
                            gifStream.CopyTo(file);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}