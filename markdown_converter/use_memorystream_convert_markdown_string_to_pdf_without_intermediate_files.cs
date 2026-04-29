// Use MemoryStream to convert a Markdown string to PDF without creating intermediate files on disk.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class CustomStreamProvider : ICreateStreamProvider, IDisposable
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
            string markdown = "# Sample Title\nThis is a **markdown** text converted to PDF.";
            HTMLDocument htmlDoc = Converter.ConvertMarkdown(markdown);
            PdfSaveOptions options = new PdfSaveOptions();
            using var provider = new CustomStreamProvider();
            Converter.ConvertHTML(htmlDoc, options, provider);
            MemoryStream pdfStream = provider.Streams[0];
            pdfStream.Position = 0;
            byte[] pdfBytes = pdfStream.ToArray();
            // Example usage: write PDF bytes to a file (optional)
            File.WriteAllBytes("output.pdf", pdfBytes);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}