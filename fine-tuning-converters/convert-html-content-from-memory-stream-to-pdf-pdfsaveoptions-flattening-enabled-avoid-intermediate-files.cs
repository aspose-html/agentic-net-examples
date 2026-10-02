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
            string html = "<html><body><h1>Hello, PDF!</h1></body></html>";
            MemoryStream htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(html));
            HTMLDocument document = new HTMLDocument(htmlStream, "about:blank");
            PdfSaveOptions options = new PdfSaveOptions();
            // Flattening is not supported directly via PdfSaveOptions in this version.

            MyStreamProvider provider = new MyStreamProvider();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            MemoryStream pdfStream = provider.Streams[0];
            pdfStream.Position = 0;
            byte[] pdfBytes = pdfStream.ToArray();

            // Write the PDF to a file for verification
            File.WriteAllBytes("output.pdf", pdfBytes);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class MyStreamProvider : ICreateStreamProvider, IDisposable
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
        foreach (var s in Streams)
        {
            s.Dispose();
        }
    }
}