// Implement ICreateStreamProvider to supply file streams for multi‑page HTML to JPEG conversion.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    // Stores all memory streams created during conversion
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    // Called by the converter for each output page (without page number)
    public Stream GetStream(string outputPath, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Called by the converter for each output page (with page number)
    public Stream GetStream(string outputPath, string extension, int pageNumber)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Not needed for this simple scenario
    public void ReleaseStream(Stream stream) { }

    // Dispose all stored streams
    public void Dispose()
    {
        foreach (var ms in Streams)
            ms.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file (multi‑page)
            string htmlPath = "input.html";

            // Directory where JPEG files will be saved
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Load HTML document
            using var document = new HTMLDocument(htmlPath);

            // Configure JPEG output
            var options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Create custom stream provider
            var provider = new MemoryStreamProvider();

            // Perform conversion – each page is written to a MemoryStream inside the provider
            Converter.ConvertHTML(document, options, provider);

            // Save each generated stream to a separate JPEG file
            int pageIndex = 0;
            foreach (var memoryStream in provider.Streams)
            {
                memoryStream.Position = 0; // rewind
                string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.jpg");
                using var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
                memoryStream.CopyTo(fileStream);
                pageIndex++;
            }

            // Clean up
            provider.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}