// Implement a service that receives HTML content via API and returns a PDF stream with default DPI.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
    public void ReleaseStream(Stream stream) { }
    public void Dispose()
    {
        foreach (var s in Streams) s.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, World!</h1></body></html>";
            string baseUrl = "";
            HTMLDocument document = new HTMLDocument(html, baseUrl);
            PdfSaveOptions options = new PdfSaveOptions();
            MemoryStreamProvider provider = new MemoryStreamProvider();
            Converter.ConvertHTML(document, options, provider);
            MemoryStream pdfStream = provider.Streams[0];
            pdfStream.Position = 0;
            byte[] pdfBytes = pdfStream.ToArray();
            File.WriteAllBytes("output.pdf", pdfBytes);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}