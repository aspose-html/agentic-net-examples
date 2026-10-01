// Load HTML from a Stream object into the validator to support network or memory‑based sources.

using System;
using System.IO;
using System.Collections.Generic;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

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
        stream.Flush();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public void Dispose()
    {
        foreach (var s in _streams)
            s.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUrl = "";

            using (var document = new Aspose.Html.HTMLDocument(html, baseUrl))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();

                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                    if (provider.Streams.Count > 0)
                    {
                        var pdfStream = provider.Streams[0];
                        pdfStream.Position = 0;
                        byte[] pdfBytes = pdfStream.ToArray();

                        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
                        File.WriteAllBytes(outputPath, pdfBytes);
                        Console.WriteLine($"PDF saved to {outputPath}, size {pdfBytes.Length} bytes.");
                    }
                    else
                    {
                        Console.WriteLine("No PDF stream was generated.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}