// Provide a custom ICreateStreamProvider to receive PDF output in memory.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        MemoryStream ms = new MemoryStream();
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
        foreach (MemoryStream ms in Streams)
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
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUrl = "about:blank";

            HTMLDocument document = new HTMLDocument(html, baseUrl);
            PdfSaveOptions options = new PdfSaveOptions();

            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                byte[] pdfBytes = pdfStream.ToArray();

                Console.WriteLine($"PDF generated in memory, size: {pdfBytes.Length} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}