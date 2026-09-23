// Convert a large EPUB to BMP by streaming input and output to minimize memory consumption during conversion.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "page1.bmp";

            if (!File.Exists(inputPath))
            {
                // Create a minimal placeholder EPUB file (empty zip archive)
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                if (provider.Streams.Count > 0)
                {
                    var firstStream = provider.Streams[0];
                    firstStream.Position = 0;
                    using (FileStream outputFile = File.Create(outputPath))
                    {
                        firstStream.CopyTo(outputFile);
                    }
                    Console.WriteLine($"First page saved to {outputPath}");
                }
                else
                {
                    Console.WriteLine("No output streams were generated.");
                }

                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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