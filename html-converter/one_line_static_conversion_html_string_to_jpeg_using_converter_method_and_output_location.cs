// Perform a one‑line static conversion of HTML string to JPEG using static Converter method and output location.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

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
}

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<h1>Convert HTML to JPG File Format!</h1>";
            string baseUri = ".";

            // Create HTML document from string
            var document = new HTMLDocument(htmlContent, baseUri);

            // Set up JPEG save options
            var options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Create in-memory stream provider
            using var provider = new MemoryStreamProvider();

            // Convert HTML to JPEG into the stream provider
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Ensure output directory exists
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            // Get the first generated memory stream
            var memoryStream = provider.Streams[0];
            memoryStream.Seek(0, SeekOrigin.Begin);

            // Save the JPEG to a file
            string outputPath = Path.Combine(outputDir, "stream-provider.jpg");
            using var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
            memoryStream.CopyTo(fileStream);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}