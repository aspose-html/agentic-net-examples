// Use ICreateStreamProvider to write converted JPEG data directly to a cloud storage stream.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
            // Sample HTML content
            string htmlContent = "<html><body><h1>Convert HTML to JPEG</h1></body></html>";
            // Create HTMLDocument with inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set JPEG save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Create in‑memory stream provider
            using (var provider = new MemoryStreamProvider())
            {
                // Convert HTML to JPEG images (one per page)
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Ensure at least one stream was generated
                if (provider.Streams.Count > 0)
                {
                    var jpegStream = provider.Streams[0];
                    jpegStream.Position = 0; // Rewind to beginning

                    // Simulate cloud storage by writing to a file
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");
                    using (var fileStream = File.Create(outputPath))
                    {
                        jpegStream.CopyTo(fileStream);
                    }

                    Console.WriteLine("JPEG image saved to: " + outputPath);
                }
                else
                {
                    Console.WriteLine("No JPEG streams were generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}