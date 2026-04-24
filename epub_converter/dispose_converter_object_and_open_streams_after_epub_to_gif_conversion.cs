// Dispose of the Converter object and any open streams after completing EPUB to GIF conversion.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string path, string contentType)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string path, string contentType, int bufferSize)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
        Streams.Clear();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string outputGifPath = "output.gif";

            using (FileStream epubStream = File.OpenRead(epubPath))
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Converter.ConvertEPUB(epubStream, options, provider);

                if (provider.Streams.Count > 0)
                {
                    provider.Streams[0].Position = 0;
                    using (FileStream outFile = File.Create(outputGifPath))
                    {
                        provider.Streams[0].CopyTo(outFile);
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