// Provide a custom ICreateStreamProvider to receive PDF output in memory.

using System;
using System.Collections.Generic;
using System.IO;

class MemoryPdfStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        if (stream != null) stream.Flush();
    }

    public void Dispose()
    {
        foreach (var ms in Streams) ms.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUrl = "about:blank";

            var document = new Aspose.Html.HTMLDocument(html, baseUrl);
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            using (var provider = new MemoryPdfStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                var pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                byte[] pdfBytes = pdfStream.ToArray();

                Console.WriteLine($"PDF generated in memory. Size: {pdfBytes.Length} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}