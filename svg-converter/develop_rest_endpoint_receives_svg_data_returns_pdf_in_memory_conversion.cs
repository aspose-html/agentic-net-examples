// Develop a REST endpoint that receives SVG data and returns PDF using in‑memory conversion.

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
        stream?.Flush();
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
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string baseUri = "http://example.com/";
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, provider);

                if (provider.Streams.Count > 0)
                {
                    var pdfStream = provider.Streams[0];
                    pdfStream.Position = 0;
                    string outputPath = "output.pdf";
                    using (var file = File.Create(outputPath))
                    {
                        pdfStream.CopyTo(file);
                    }
                    Console.WriteLine($"PDF saved to {Path.GetFullPath(outputPath)}");
                }
                else
                {
                    Console.WriteLine("No PDF stream was generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}