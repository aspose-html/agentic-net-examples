// Create a custom ImageDevice, render HTML, and write the resulting PNG to a memory stream.

using System;
using System.Collections.Generic;
using System.IO;

sealed class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        // No action needed for in‑memory streams
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

            // Configure image save options (PNG)
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Use custom stream provider
            using var provider = new MemoryStreamProvider();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Save the first generated image to a file
            if (provider.Streams.Count > 0)
            {
                var stream = provider.Streams[0];
                stream.Position = 0;
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");
                using var file = File.Create(outputPath);
                stream.CopyTo(file);
                Console.WriteLine($"Image saved to: {outputPath}");
            }
            else
            {
                Console.WriteLine("No image streams were generated.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}