// Develop a REST endpoint that receives SVG data and returns PDF using in‑memory conversion.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
    public void ReleaseStream(Stream stream) { }
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
            string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";
            string baseUri = "";
            PdfSaveOptions options = new PdfSaveOptions();
            using (var provider = new MemoryStreamProvider())
            {
                Converter.ConvertSVG(svgContent, baseUri, options, provider);
                MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                byte[] pdfBytes = pdfStream.ToArray();
                File.WriteAllBytes("output.pdf", pdfBytes);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}