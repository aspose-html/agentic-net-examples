// Create a function that accepts a stream provider and returns the size of the converted image in bytes.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

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
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Create HTML document from content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure image save options (PNG format)
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Create custom stream provider
            var provider = new MemoryStreamProvider();

            // Convert HTML to image using the provider
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Get size of the first generated image in bytes
            long imageSize = GetConvertedImageSize(provider);
            Console.WriteLine($"Converted image size: {imageSize} bytes");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static long GetConvertedImageSize(MemoryStreamProvider provider)
    {
        if (provider.Streams.Count > 0)
        {
            var stream = provider.Streams[0];
            stream.Position = 0;
            return stream.Length;
        }
        return 0;
    }
}