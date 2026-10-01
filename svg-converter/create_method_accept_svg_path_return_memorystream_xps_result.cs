// Create a method that accepts an SVG path and returns a MemoryStream containing the XPS result.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

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
        if (stream != null)
        {
            stream.Flush();
        }
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
  <circle cx='100' cy='100' r='80' fill='orange' />
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='white'>SVG</text>
</svg>";

            string baseUri = "http://example.com/";
            string outputPath = "output.pdf";

            // Create provider for in‑memory output
            using (var provider = new MemoryStreamProvider())
            {
                // PDF save options (default)
                var options = new PdfSaveOptions();

                // Convert SVG to PDF using the provider
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, provider);

                // Retrieve the generated PDF stream
                if (provider.Streams.Count > 0)
                {
                    var pdfStream = provider.Streams[0];
                    pdfStream.Position = 0;
                    using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        pdfStream.CopyTo(fileStream);
                    }

                    Console.WriteLine($"PDF saved to '{Path.GetFullPath(outputPath)}'.");
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