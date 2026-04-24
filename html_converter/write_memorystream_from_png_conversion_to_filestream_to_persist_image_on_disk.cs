// Write the MemoryStream obtained from PNG conversion to a FileStream to persist the image on disk.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

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
        stream?.Flush();
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
            string epubPath = "sample.epub";
            string outputPath = "output.png";

            using Stream epubStream = File.OpenRead(epubPath);
            ImageSaveOptions options = new ImageSaveOptions();

            using var provider = new MemoryStreamProvider();
            Converter.ConvertEPUB(epubStream, options, provider);

            MemoryStream resultStream = provider.Streams[0];
            resultStream.Position = 0;

            using FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
            resultStream.CopyTo(fileStream);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}