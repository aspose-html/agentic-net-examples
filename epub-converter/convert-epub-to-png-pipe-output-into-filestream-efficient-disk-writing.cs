// Convert EPUB to PNG and pipe the output into a FileStream for efficient disk writing.

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
            string inputPath = "sample.epub";
            string outputDirectory = "output";

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Ensure a sample EPUB exists (minimal placeholder)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            using (var provider = new MemoryStreamProvider())
            {
                ImageSaveOptions options = new ImageSaveOptions();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                for (int i = 0; i < provider.Streams.Count; i++)
                {
                    MemoryStream resultStream = provider.Streams[i];
                    resultStream.Position = 0;
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        resultStream.CopyTo(fileStream);
                    }
                }
            }

            Console.WriteLine("EPUB conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}