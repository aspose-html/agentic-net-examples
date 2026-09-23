// Convert EPUB to BMP using a FileStream to save the image file with explicit resource management.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

public class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        // No additional actions required for in-memory streams
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string epubPath = "sample.epub";
            string outputPath = "output.bmp";

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                var options = new ImageSaveOptions(ImageFormat.Bmp);
                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    if (provider.Streams.Count > 0)
                    {
                        var resultStream = provider.Streams[0];
                        resultStream.Position = 0;
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            resultStream.CopyTo(fileStream);
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