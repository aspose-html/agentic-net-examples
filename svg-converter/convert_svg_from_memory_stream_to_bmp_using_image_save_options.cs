// Convert an SVG loaded from a memory stream directly to BMP using ConvertSVG overload with ImageSaveOptions.

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

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
        // For this example, page handling is the same as without page.
        return GetStream(name, extension);
    }

    public void ReleaseStream(Stream stream)
    {
        // Ensure any buffered data is written.
        stream.Flush();
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
            // Sample SVG content
            string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange' stroke='black' stroke-width='5'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='black'>Demo</text>
</svg>";

            // Base URI (required by the converter)
            string baseUri = "http://example.com/";

            // Set up image save options for BMP format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Use a custom stream provider to capture the output in memory
            using (var provider = new MemoryStreamProvider())
            {
                // Convert SVG content to BMP image(s) using the provider
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, provider);

                // Ensure we have at least one generated stream
                if (provider.Streams.Count > 0)
                {
                    // Get the first generated image stream
                    var imageStream = provider.Streams[0];
                    imageStream.Position = 0; // rewind

                    // Save the image bytes to a file for verification
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_from_provider.bmp");
                    using (var fileStream = File.Create(outputPath))
                    {
                        imageStream.CopyTo(fileStream);
                    }

                    Console.WriteLine($"Image saved to: {outputPath}");
                }
                else
                {
                    Console.WriteLine("No image streams were generated.");
                }
            }

            // Simple file‑based conversion (no provider) for comparison
            string svgFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.svg");
            File.WriteAllText(svgFilePath, svgContent);

            string fileOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output_from_file.bmp");
            var fileOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            Aspose.Html.Converters.Converter.ConvertSVG(svgFilePath, fileOptions, fileOutputPath);

            Console.WriteLine($"File‑based conversion saved to: {fileOutputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}