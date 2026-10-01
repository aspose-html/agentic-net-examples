// Write the MemoryStream obtained from PNG conversion to a FileStream to persist the image on disk.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

sealed class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        // No action needed for in-memory streams
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
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Create HTML document
            var document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Configure image save options for PNG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Create custom stream provider to capture the output in memory
            using (var provider = new MemoryStreamProvider())
            {
                // Convert HTML to PNG using the provider
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Save the first generated PNG stream to a file
                if (provider.Streams.Count > 0)
                {
                    var memoryStream = provider.Streams[0];
                    memoryStream.Position = 0;
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        memoryStream.CopyTo(fileStream);
                    }
                    Console.WriteLine($"Image saved to: {outputPath}");
                }
                else
                {
                    Console.WriteLine("No image streams were generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}