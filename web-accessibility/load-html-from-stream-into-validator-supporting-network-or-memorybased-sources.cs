// Load HTML from a Stream object into the validator to support network or memory‑based sources.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Html.IO;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<System.IO.MemoryStream> _streams = new List<System.IO.MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new System.IO.MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new System.IO.MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
        }
    }

    public System.Collections.Generic.IReadOnlyList<System.IO.MemoryStream> Streams => _streams;

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, World!</h1></body></html>";
            System.IO.MemoryStream htmlStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(html));
            string baseUrl = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlStream, baseUrl);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            MemoryStreamProvider provider = new MemoryStreamProvider();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            if (provider.Streams.Count > 0)
            {
                System.IO.MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                using (System.IO.FileStream fileStream = new System.IO.FileStream("output.pdf", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    pdfStream.CopyTo(fileStream);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}