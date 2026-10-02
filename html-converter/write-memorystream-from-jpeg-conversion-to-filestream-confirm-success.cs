// Write the MemoryStream obtained from JPEG conversion to a FileStream and confirm successful write.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var memoryStream = new MemoryStream();
        _streams.Add(memoryStream);
        return memoryStream;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var memoryStream = new MemoryStream();
        _streams.Add(memoryStream);
        return memoryStream;
    }

    public void ReleaseStream(System.IO.Stream stream)
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

class Program
{
    static void Main()
    {
        try
        {
            // Prepare HTML content
            string htmlContent = "<h1>Convert HTML to JPG File Format!</h1>";
            string baseUri = "about:blank";

            // Create HTML document
            var document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Set JPEG save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Create stream provider to capture output in memory
            var provider = new MemoryStreamProvider();

            // Convert HTML to JPEG using the provider
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Ensure at least one stream was generated
            if (provider.Streams.Count == 0)
                throw new InvalidOperationException("No output streams were generated.");

            // Get the first memory stream containing JPEG data
            var jpegStream = provider.Streams[0];
            jpegStream.Seek(0, SeekOrigin.Begin);

            // Prepare output path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "stream-provider.jpg");

            // Write memory stream to file
            using (FileStream fileStream = File.Create(outputPath))
            {
                jpegStream.CopyTo(fileStream);
            }

            Console.WriteLine($"JPEG image successfully written to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}