// Convert HTML to PDF and produce byte[] output (BLOB-ready)

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to convert
            string html = "<html><body><h1>Hello, Aspose!</h1></body></html>";
            string baseUrl = "";

            // Load HTML into a document
            HTMLDocument document = new HTMLDocument(html, baseUrl);

            // PDF conversion options
            PdfSaveOptions options = new PdfSaveOptions();

            // In‑memory stream provider to capture PDF bytes
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Perform conversion
                Converter.ConvertHTML(document, options, provider);

                // Retrieve the generated PDF stream
                MemoryStream pdfStream = provider.Streams.First();
                pdfStream.Position = 0;

                // Get PDF as byte array (BLOB‑ready)
                byte[] pdfBytes = pdfStream.ToArray();

                // Example: write PDF to a file
                File.WriteAllBytes("output.pdf", pdfBytes);
                Console.WriteLine($"PDF generated, size: {pdfBytes.Length} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom provider that stores output in memory streams
class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public System.Collections.Generic.List<MemoryStream> Streams { get; } = new System.Collections.Generic.List<MemoryStream>();

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
        foreach (var s in Streams)
            s.Dispose();
    }
}