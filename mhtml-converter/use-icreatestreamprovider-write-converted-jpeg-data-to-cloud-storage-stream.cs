// Use ICreateStreamProvider to write converted JPEG data directly to a cloud storage stream.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are retained for later use.
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
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";

            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            MemoryStreamProvider provider = new MemoryStreamProvider();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            if (provider.Streams.Count > 0)
            {
                MemoryStream jpegStream = provider.Streams[0];
                jpegStream.Position = 0;

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");
                using (FileStream fileStream = File.Create(outputPath))
                {
                    jpegStream.CopyTo(fileStream);
                }

                Console.WriteLine($"JPEG image saved to: {outputPath}");
            }
            else
            {
                Console.WriteLine("No JPEG streams were generated.");
            }

            provider.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}