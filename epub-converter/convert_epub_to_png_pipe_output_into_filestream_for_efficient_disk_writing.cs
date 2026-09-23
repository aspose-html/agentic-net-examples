// Convert EPUB to PNG and pipe the output into a FileStream for efficient disk writing.

using System;
using System.IO;
using System.Collections.Generic;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        // No action needed
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
            string inputPath = "sample.epub";

            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using Stream epubStream = File.OpenRead(inputPath);
            var options = new Aspose.Html.Saving.ImageSaveOptions();
            using var provider = new MemoryStreamProvider();

            Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

            int index = 0;
            foreach (var ms in provider.Streams)
            {
                ms.Position = 0;
                string outputPath = $"page_{index}.png";
                using FileStream fileStream = File.Create(outputPath);
                ms.CopyTo(fileStream);
                index++;
            }

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}