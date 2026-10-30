// Store extracted images in memory streams for further processing before writing to disk.

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
            string epubPath = "sample.epub";
            string outputDir = "output_images";
            Directory.CreateDirectory(outputDir);

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    int index = 0;
                    foreach (MemoryStream ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outPath = Path.Combine(outputDir, $"image_{index}.png");
                        using (FileStream fileStream = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                        {
                            ms.CopyTo(fileStream);
                        }
                        index++;
                    }

                    // Example of further processing: obtain byte array of the first image
                    if (provider.Streams.Count > 0)
                    {
                        byte[] firstImageBytes = provider.Streams[0].ToArray();
                        // Further processing can be done with firstImageBytes here
                    }
                }
            }

            Console.WriteLine("Image extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}