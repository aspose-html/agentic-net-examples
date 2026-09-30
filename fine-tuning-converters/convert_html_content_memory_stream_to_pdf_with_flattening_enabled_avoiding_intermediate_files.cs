// Convert HTML content from a memory stream to PDF using PdfSaveOptions with flattening enabled, avoiding intermediate files.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, World!</h1></body></html>";
            MemoryStream htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(html));
            HTMLDocument document = new HTMLDocument(htmlStream, "http://example.com/");
            PdfSaveOptions options = new PdfSaveOptions();
            MemoryStreamProvider provider = new MemoryStreamProvider();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
            MemoryStream pdfStream = provider.Streams[0];
            pdfStream.Position = 0;
            byte[] pdfBytes = pdfStream.ToArray();
            File.WriteAllBytes("output.pdf", pdfBytes);
            Console.WriteLine("PDF generated successfully. Size: " + pdfBytes.Length + " bytes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

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

    public void ReleaseStream(Stream stream)
    {
        // No action needed
    }

    public void Dispose()
    {
        foreach (MemoryStream ms in Streams)
        {
            ms.Dispose();
        }
    }
}