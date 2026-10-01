// Use a custom ICreateStreamProvider to store GIF output directly into a cloud storage bucket.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html;

class CloudGifStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private List<MemoryStream> _streams = new List<MemoryStream>();

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
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
    }

    public Stream GetFirstStream()
    {
        return _streams.Count > 0 ? _streams[0] : null;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Create HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set image save options for GIF format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Initialize custom stream provider
            using (var provider = new CloudGifStreamProvider())
            {
                // Convert HTML to GIF using the provider
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Retrieve the generated GIF stream
                var gifStream = provider.GetFirstStream();
                if (gifStream != null)
                {
                    gifStream.Position = 0;

                    // Simulate uploading to a cloud storage bucket by saving to a local path
                    string outputPath = "cloud_bucket/output.gif";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var file = File.Create(outputPath))
                    {
                        gifStream.CopyTo(file);
                    }

                    Console.WriteLine($"GIF image saved to: {outputPath}");
                }
                else
                {
                    Console.WriteLine("No GIF stream was generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}