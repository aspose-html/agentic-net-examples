// Save a modified HTMLDocument to a MemoryStream with UTF‑8 encoding for further processing.

using System;
using System.IO;
using System.Collections.Generic;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
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
        foreach (var ms in Streams)
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
            string html = "<html><body><h1>Hello Aspose.HTML</h1></body></html>";
            string baseUrl = "http://example.com/";

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
                        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
                        using (var file = File.Create(outputPath))
                        {
                            pdfStream.CopyTo(file);
                        }
                        Console.WriteLine($"PDF saved to: {outputPath}");
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