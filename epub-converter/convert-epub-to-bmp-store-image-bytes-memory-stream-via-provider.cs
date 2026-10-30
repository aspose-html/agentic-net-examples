// Convert EPUB to BMP and store the resulting image bytes in a memory stream via provider.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            using (Stream inputStream = File.OpenRead(inputPath))
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                if (provider.Streams.Count > 0)
                {
                    MemoryStream resultStream = provider.Streams[0];
                    resultStream.Position = 0;
                    byte[] imageBytes = resultStream.ToArray();
                    Console.WriteLine($"Conversion successful. BMP byte size: {imageBytes.Length}");
                }
                else
                {
                    Console.WriteLine("No output streams were generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}