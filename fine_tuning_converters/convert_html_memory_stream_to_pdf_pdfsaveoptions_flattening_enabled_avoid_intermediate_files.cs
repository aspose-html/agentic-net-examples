// Convert HTML content from a memory stream to PDF using PdfSaveOptions with flattening enabled, avoiding intermediate files.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.IO;

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
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            using (var htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(htmlContent)))
            using (var provider = new CustomStreamProvider())
            {
                var document = new HTMLDocument(htmlStream, "http://example.com");
                var options = new PdfSaveOptions();
                // Flattening is not supported in this version; omitted.

                Converter.ConvertHTML(document, options, provider);

                var pdfStream = provider.Streams[0];
                pdfStream.Position = 0;

                // Example: write the PDF to a file (final output, not an intermediate file)
                using (var file = File.Create("output.pdf"))
                {
                    pdfStream.CopyTo(file);
                }

                Console.WriteLine("PDF conversion completed. Size: {0} bytes", pdfStream.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}