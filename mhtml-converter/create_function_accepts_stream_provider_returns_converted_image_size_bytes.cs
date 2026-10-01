// Create a function that accepts a stream provider and returns the size of the converted image in bytes.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

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
            var provider = new MemoryStreamProvider();
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
        // Create a simple HTML document
        var htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
        var document = new Aspose.Html.HTMLDocument(htmlContent, "");

        // Configure image save options (PNG format)
        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

        // Perform conversion using the provider
        Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

        // Retrieve the first generated image stream and return its size
        if (provider.Streams.Count > 0)
        {
            var resultStream = provider.Streams[0];
            resultStream.Position = 0;
            return resultStream.Length;
        }

        return 0;
    }
}