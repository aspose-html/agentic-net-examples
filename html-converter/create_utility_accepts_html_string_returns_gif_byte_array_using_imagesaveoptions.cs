// Create a utility that accepts HTML string and returns a GIF byte array using ImageSaveOptions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            byte[] gifBytes = ConvertHtmlToGif(htmlContent);
            Console.WriteLine($"Generated GIF byte array length: {gifBytes.Length}");
            // Optionally save to file for verification
            string outputPath = "output.gif";
            File.WriteAllBytes(outputPath, gifBytes);
            Console.WriteLine($"GIF saved to: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] ConvertHtmlToGif(string html)
    {
        // Create HTML document from string
        HTMLDocument document = new HTMLDocument(html);

        // Set image save options for GIF format
        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

        // Create in-memory stream provider
        MemoryStreamProvider provider = new MemoryStreamProvider();

        // Convert HTML to GIF using the provider
        Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

        // Retrieve the generated stream
        if (provider.Streams.Count == 0)
            throw new InvalidOperationException("No output stream was generated.");

        MemoryStream resultStream = provider.Streams[0];
        resultStream.Position = 0;
        byte[] resultBytes = resultStream.ToArray();

        // Cleanup
        provider.Dispose();

        return resultBytes;
    }
}

// In-memory stream provider implementation
class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

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
        _streams.Clear();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams;
}