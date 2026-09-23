// Stream EPUB content from a network source into a MemoryStream before converting it to a GIF.

using System;
using System.IO;
using System.Net.Http;
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
            // URL of the EPUB file (replace with a valid URL if needed)
            string epubUrl = "https://example.com/sample.epub";
            // Output GIF file path
            string outputPath = "output.gif";

            // Download EPUB content into a MemoryStream
            using (var httpClient = new HttpClient())
            using (var response = httpClient.GetAsync(epubUrl).Result)
            using (var networkStream = response.Content.ReadAsStreamAsync().Result)
            using (var epubMemory = new MemoryStream())
            {
                networkStream.CopyTo(epubMemory);
                epubMemory.Position = 0;

                // Prepare conversion options
                var options = new ImageSaveOptions(ImageFormat.Gif);

                // Create custom stream provider
                using (var provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to GIF using the provider
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubMemory, options, provider);

                    // Retrieve the generated GIF stream
                    if (provider.Streams.Count > 0)
                    {
                        var gifStream = provider.Streams[0];
                        gifStream.Position = 0;
                        using (var fileStream = File.Create(outputPath))
                        {
                            gifStream.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Conversion completed. GIF saved to '{outputPath}'.");
                    }
                    else
                    {
                        Console.WriteLine("No output streams were generated.");
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