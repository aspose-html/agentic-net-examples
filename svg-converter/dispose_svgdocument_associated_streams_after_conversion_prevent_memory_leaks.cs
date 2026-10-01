// Dispose SVGDocument and all associated streams after conversion to prevent memory leaks.

using System;
using System.IO;
using System.Collections.Generic;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        stream?.Flush();
    }

    public void Dispose()
    {
        foreach (var s in _streams)
            s.Dispose();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            string svgContent = "<svg width=\"100\" height=\"100\" xmlns=\"http://www.w3.org/2000/svg\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg>";
            string baseUri = "http://example.com/";
            string outputPath = "output.pdf";

            var options = new Aspose.Html.Saving.PdfSaveOptions();

            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, provider);
                var pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                using (var file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    pdfStream.CopyTo(file);
                }
            }

            Console.WriteLine("PDF saved to " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}