// Convert HTML to PNG and compress the resulting file using GZip stream before saving to disk.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    // Holds the memory stream where the PNG data will be written
    public MemoryStream Stream { get; private set; }

    // Called by Aspose.HTML to obtain a stream for output
    public Stream GetStream(string path, string extension)
    {
        Stream = new MemoryStream();
        return Stream;
    }

    // Overload with index parameter
    public Stream GetStream(string path, string extension, int index)
    {
        Stream = new MemoryStream();
        return Stream;
    }

    // Called after conversion is done; no special handling needed
    public void ReleaseStream(Stream stream) { }

    // Dispose the internal memory stream
    public void Dispose()
    {
        Stream?.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<html><body><h1>Hello, Aspose!</h1></body></html>";
            string baseUrl = "http://example.com";

            // Provider that captures the generated PNG into a memory stream
            using var provider = new MemoryStreamProvider();

            // Create HTML document from string and base URL
            var document = new HTMLDocument(html, baseUrl);

            // Configure image save options for PNG format
            var options = new ImageSaveOptions(ImageFormat.Png);

            // Perform conversion: HTML -> PNG (written to provider's stream)
            Converter.ConvertHTML(document, options, provider);

            // Prepare to compress the PNG data
            provider.Stream.Position = 0;
            string outputPath = "output.png.gz";

            // Write compressed data to disk using GZipStream
            using (var fileStream = File.Create(outputPath))
            using (var gzip = new GZipStream(fileStream, CompressionMode.Compress))
            {
                provider.Stream.CopyTo(gzip);
            }

            Console.WriteLine("HTML converted to PNG and compressed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}