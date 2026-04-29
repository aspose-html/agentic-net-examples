// Dispose the HTMLDocument after conversion to release unmanaged resources and avoid memory leaks.

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
            // HTML content to convert
            string html = "<html><body><h1>Hello World</h1></body></html>";
            string baseUrl = "";

            // Create HTML document
            HTMLDocument document = new HTMLDocument(html, baseUrl);

            // Set PDF conversion options
            PdfSaveOptions options = new PdfSaveOptions();

            // Provider to capture output in memory
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Perform conversion
                Converter.ConvertHTML(document, options, provider);

                // Retrieve generated PDF stream
                MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                byte[] pdfBytes = pdfStream.ToArray();

                // Save PDF to file (optional)
                File.WriteAllBytes("output.pdf", pdfBytes);
            }

            // Dispose the HTML document to release unmanaged resources
            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}