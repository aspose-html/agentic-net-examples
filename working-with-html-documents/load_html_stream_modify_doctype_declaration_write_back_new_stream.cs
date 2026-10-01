// Load HTML from a stream, modify its DOCTYPE declaration, and write back to a new stream.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

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
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            using (var document = new HTMLDocument(inputPath))
            {
                // Add a simple watermark using a DIV overlay
                Element div = document.CreateElement("div");
                div.SetAttribute("style", "position:absolute;top:10px;right:10px;font-size:24px;color:red;opacity:0.5;");
                div.TextContent = "Watermark";
                document.Body.AppendChild(div);

                var options = new PdfSaveOptions();

                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
                    var pdfStream = provider.Streams[0];
                    pdfStream.Position = 0;

                    string outputPath = "output.pdf";
                    using (var fs = File.Create(outputPath))
                    {
                        pdfStream.CopyTo(fs);
                    }

                    Console.WriteLine($"PDF saved to {outputPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}