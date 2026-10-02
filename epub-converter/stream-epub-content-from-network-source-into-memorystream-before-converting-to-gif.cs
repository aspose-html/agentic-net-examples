// Stream EPUB content from a network source into a MemoryStream before converting it to a GIF.

using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();
    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
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
            // Input EPUB URL (replace with a valid URL)
            string epubUrl = "https://example.com/sample.epub";
            // Output GIF file path
            string outputPath = "output.gif";

            // Download EPUB content into a MemoryStream
            using var httpClient = new HttpClient();
            using var response = httpClient.GetAsync(epubUrl).Result;
            response.EnsureSuccessStatusCode();
            using var networkStream = response.Content.ReadAsStreamAsync().Result;
            using var epubMemory = new MemoryStream();
            networkStream.CopyTo(epubMemory);
            epubMemory.Position = 0;

            // Set image save options for GIF format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Create custom stream provider to capture output streams
            using var provider = new MemoryStreamProvider();

            // Convert EPUB to GIF using the provider
            Aspose.Html.Converters.Converter.ConvertEPUB(epubMemory, options, provider);

            // Retrieve the first generated GIF stream and save to file
            if (provider.Streams.Count > 0)
            {
                var gifStream = provider.Streams[0];
                gifStream.Position = 0;
                using var fileStream = File.Create(outputPath);
                gifStream.CopyTo(fileStream);
                Console.WriteLine($"GIF saved to: {outputPath}");
            }
            else
            {
                Console.WriteLine("No GIF stream was generated.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}