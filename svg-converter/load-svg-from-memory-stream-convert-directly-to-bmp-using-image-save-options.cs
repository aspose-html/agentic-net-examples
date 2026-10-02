// Load an SVG from a memory stream and convert it directly to BMP using ImageSaveOptions.

using System;
using System.IO;
using System.Collections.Generic;

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
                                      <circle cx='100' cy='100' r='80' fill='orange'/>
                                   </svg>";

            // Load SVG from the string content (base URI is dummy because there are no external resources)
            var svgDocument = new Aspose.Html.Dom.Svg.SVGDocument(svgContent, "about:blank");

            // Set up image save options for BMP format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Create a custom stream provider to capture the output in memory
            using (var provider = new MemoryStreamProvider())
            {
                // Convert SVG to BMP using the provider
                Aspose.Html.Converters.Converter.ConvertSVG(svgDocument, options, provider);

                // Retrieve the generated BMP bytes
                if (provider.Streams.Count > 0)
                {
                    var bmpStream = provider.Streams[0];
                    bmpStream.Position = 0;
                    byte[] bmpBytes = bmpStream.ToArray();

                    // Save the BMP to a file
                    string outputPath = "output.bmp";
                    File.WriteAllBytes(outputPath, bmpBytes);
                    Console.WriteLine($"SVG has been successfully converted to BMP and saved to '{outputPath}'.");
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