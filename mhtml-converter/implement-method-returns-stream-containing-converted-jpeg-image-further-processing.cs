// Implement a method that returns a stream containing the converted JPEG image for further processing.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
            string html = "<h1>Convert HTML to JPEG!</h1>";
            using (Stream jpegStream = ConvertHtmlToJpegStream(html))
            {
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    jpegStream.CopyTo(fileStream);
                }
                Console.WriteLine($"JPEG image saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Stream ConvertHtmlToJpegStream(string htmlContent)
    {
        // Create HTML document from inline content
        var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

        // Set image save options for JPEG format
        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

        // Create in-memory stream provider
        using (var provider = new MemoryStreamProvider())
        {
            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Retrieve the first generated memory stream
            if (provider.Streams.Count == 0)
                throw new InvalidOperationException("No image streams were generated.");

            MemoryStream generatedStream = provider.Streams[0];
            generatedStream.Position = 0;

            // Return a copy of the stream to the caller
            var result = new MemoryStream(generatedStream.ToArray());
            return result;
        }
    }
}