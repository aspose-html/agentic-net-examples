// Convert a large EPUB to BMP by streaming input and output to minimize memory consumption during conversion.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
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
            string outputPath = "output.bmp";

            // Ensure a sample EPUB exists (minimal placeholder)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]); // placeholder empty file
            }

            using (Stream inputStream = File.OpenRead(inputPath))
            using (var provider = new MemoryStreamProvider())
            {
                var options = new ImageSaveOptions(ImageFormat.Bmp);
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                if (provider.Streams.Count > 0)
                {
                    var resultStream = provider.Streams[0];
                    resultStream.Position = 0;
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        resultStream.CopyTo(fileStream);
                    }
                    Console.WriteLine($"Conversion completed. BMP saved to '{outputPath}'.");
                }
                else
                {
                    Console.WriteLine("No output streams were generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}