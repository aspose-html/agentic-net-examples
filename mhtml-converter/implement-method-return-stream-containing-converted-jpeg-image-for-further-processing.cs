// Implement a method that returns a stream containing the converted JPEG image for further processing.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        // No action needed for in‑memory streams
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            using (Stream jpegStream = ConvertHtmlToJpeg())
            {
                // Example of further processing: save to a file
                const string outputPath = "output.jpg";
                using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    jpegStream.CopyTo(file);
                }
                Console.WriteLine($"JPEG image saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Stream ConvertHtmlToJpeg()
    {
        // Create a provider that stores generated streams in memory
        var provider = new MemoryStreamProvider();

        // Initialize HTML document with inline content
        string htmlContent = "<h1>Convert HTML to JPEG using Aspose.HTML</h1>";
        var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

        // Set image save options for JPEG format
        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

        // Perform conversion; the JPEG data will be written to the provider
        Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

        // Retrieve the first generated memory stream
        if (provider.Streams.Count == 0)
            throw new InvalidOperationException("No image stream was generated.");

        MemoryStream resultStream = provider.Streams[0];
        resultStream.Seek(0, SeekOrigin.Begin);
        return resultStream;
    }
}