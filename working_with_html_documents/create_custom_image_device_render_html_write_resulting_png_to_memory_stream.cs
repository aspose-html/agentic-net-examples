// Create a custom ImageDevice, render HTML, and write the resulting PNG to a memory stream.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

sealed class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    // Stores all created memory streams
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    // Called by the converter to obtain a stream for output
    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Overload used when multiple pages are generated
    public Stream GetStream(string name, string extension, int index)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Required by the interface – no special handling needed
    public void ReleaseStream(Stream stream) { }

    public void Dispose() { }
}

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "";

            // Create an HTML document from the string
            var document = new HTMLDocument(html, baseUri);

            // Configure PNG output options
            var options = new ImageSaveOptions(ImageFormat.Png);

            // Use the custom stream provider to capture the PNG in memory
            using var provider = new MemoryStreamProvider();
            Converter.ConvertHTML(document, options, provider);

            // Retrieve the generated PNG stream
            if (provider.Streams.Count > 0)
            {
                var pngStream = provider.Streams[0];
                pngStream.Position = 0; // Reset for reading

                // Example: display the size of the generated PNG
                Console.WriteLine($"Generated PNG size: {pngStream.Length} bytes");
            }
            else
            {
                Console.WriteLine("No PNG was generated.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}