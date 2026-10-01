// Save the document as PNG using HTMLDocument.Save with ImageSaveOptions specifying PNG format.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

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
        // No action needed for in‑memory streams
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
            // Define input HTML content and output file path
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string outputPath = "output.png";

            // Configure image save options (PNG format)
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Load HTML document from the string content
            var document = new Aspose.Html.HTMLDocument(htmlContent, string.Empty);

            // Create a stream provider to capture the in‑memory result
            using (var provider = new MemoryStreamProvider())
            {
                // Convert HTML to PNG using the provider
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Ensure at least one stream was produced
                if (provider.Streams.Count > 0)
                {
                    var resultStream = provider.Streams[0];
                    resultStream.Position = 0; // rewind before reading

                    // Write the PNG data to the output file
                    using (var fileStream = File.Create(outputPath))
                    {
                        resultStream.CopyTo(fileStream);
                    }

                    Console.WriteLine($"Conversion succeeded. PNG saved to: {Path.GetFullPath(outputPath)}");
                }
                else
                {
                    Console.WriteLine("No output stream was generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}