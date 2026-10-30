// Stream EPUB content from a network source into a MemoryStream before converting it to a GIF.

using System;
using System.IO;
using System.Net.Http;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public System.Collections.Generic.List<MemoryStream> Streams { get; } = new System.Collections.Generic.List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
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

    public MemoryStream GetFirstStream()
    {
        return Streams.Count > 0 ? Streams[0] : null;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // URL of the EPUB file to download
            string epubUrl = "https://example.com/sample.epub";
            // Path where the resulting GIF will be saved
            string outputPath = "output.gif";

            // Download EPUB content into a MemoryStream
            using (HttpClient httpClient = new HttpClient())
            using (HttpResponseMessage response = httpClient.GetAsync(epubUrl).Result)
            {
                response.EnsureSuccessStatusCode();
                using (Stream networkStream = response.Content.ReadAsStreamAsync().Result)
                using (MemoryStream epubMemory = new MemoryStream())
                {
                    networkStream.CopyTo(epubMemory);
                    epubMemory.Position = 0;

                    // Set image conversion options to GIF
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                    // Create custom stream provider to capture output in memory
                    using (MemoryStreamProvider provider = new MemoryStreamProvider())
                    {
                        // Convert EPUB to GIF using the provider
                        Aspose.Html.Converters.Converter.ConvertEPUB(epubMemory, options, provider);

                        // Retrieve the generated GIF stream
                        MemoryStream gifStream = provider.GetFirstStream();
                        if (gifStream != null)
                        {
                            gifStream.Position = 0;
                            using (FileStream file = File.Create(outputPath))
                            {
                                gifStream.CopyTo(file);
                            }
                            Console.WriteLine($"GIF image saved to: {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine("No GIF stream was generated.");
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