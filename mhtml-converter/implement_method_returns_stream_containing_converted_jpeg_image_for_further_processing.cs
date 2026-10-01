// Implement a method that returns a stream containing the converted JPEG image for further processing.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.IO;

public class MemoryStreamProvider : IDisposable, ICreateStreamProvider
{
    private List<MemoryStream> _streams = new List<MemoryStream>();

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

public class Program
{
    public static void Main()
    {
        try
        {
            using (Stream jpegStream = ConvertHtmlToJpeg("<h1>Convert HTML to JPEG!</h1>"))
            {
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    jpegStream.CopyTo(fileStream);
                }
                Console.WriteLine("JPEG image saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public static Stream ConvertHtmlToJpeg(string htmlContent)
    {
        // Create HTML document
        HTMLDocument document = new HTMLDocument(htmlContent, ".");

        // Set image save options for JPEG format
        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

        // Create in-memory stream provider
        MemoryStreamProvider provider = new MemoryStreamProvider();

        // Perform conversion
        Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

        // Retrieve the first generated memory stream
        if (provider.Streams.Count == 0)
        {
            throw new InvalidOperationException("No image streams were generated.");
        }

        MemoryStream resultStream = provider.Streams[0];
        resultStream.Seek(0, SeekOrigin.Begin);
        return resultStream;
    }
}