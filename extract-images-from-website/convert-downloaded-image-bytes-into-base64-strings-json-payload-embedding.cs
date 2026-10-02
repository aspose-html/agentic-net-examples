// Convert downloaded image bytes to Base64 strings for embedding into JSON payloads.

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using Aspose.Html.IO;

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
            // Prepare a sample PNG image (1x1 red pixel) if it does not exist
            string sampleImagePath = "sample.png";
            if (!File.Exists(sampleImagePath))
            {
                using (var bmp = new Bitmap(1, 1))
                {
                    bmp.SetPixel(0, 0, Color.Red);
                    bmp.Save(sampleImagePath, ImageFormat.Png);
                }
            }

            // Read image bytes and convert to Base64
            byte[] imageBytes = File.ReadAllBytes(sampleImagePath);
            string base64Image = Convert.ToBase64String(imageBytes);

            // Create HTML content embedding the image
            string htmlContent = $"<html><body><img src='data:image/png;base64,{base64Image}'/></body></html>";

            // Initialize stream provider
            using (var provider = new MemoryStreamProvider())
            {
                // Create HTML document from inline content
                var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                // Set image save options (PNG format)
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

                // Convert HTML to PNG using the provider
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Retrieve the generated PNG stream
                if (provider.Streams.Count == 0)
                    throw new InvalidOperationException("No output stream was generated.");

                var outputStream = provider.Streams[0];
                outputStream.Position = 0;

                // Save the PNG to a file
                string outputPath = "output.png";
                using (var fileStream = File.Create(outputPath))
                {
                    outputStream.CopyTo(fileStream);
                }

                // Convert the resulting PNG to Base64 for JSON payload
                string outputBase64 = Convert.ToBase64String(File.ReadAllBytes(outputPath));
                string jsonPayload = $"{{\"image\":\"{outputBase64}\"}}";

                Console.WriteLine("JSON payload with embedded image:");
                Console.WriteLine(jsonPayload);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}