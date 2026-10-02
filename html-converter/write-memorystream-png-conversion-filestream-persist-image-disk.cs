// Write the MemoryStream obtained from PNG conversion to a FileStream to persist the image on disk.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

sealed class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        // No action needed for in-memory streams
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
            const string htmlContent = "<html><body><h1>Hello, Aspose!</h1></body></html>";
            const string outputPath = "output.png";

            using (var document = new HTMLDocument(htmlContent, "about:blank"))
            {
                var options = new ImageSaveOptions(ImageFormat.Png);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                if (provider.Streams.Count > 0)
                {
                    var imageStream = provider.Streams[0];
                    imageStream.Position = 0;
                    using (var fileStream = File.Create(outputPath))
                    {
                        imageStream.CopyTo(fileStream);
                    }
                }

                provider.Dispose();
            }

            Console.WriteLine("Image saved to output.png");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}