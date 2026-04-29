// Provide a custom ICreateStreamProvider to receive PDF output in memory.

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

    public void ReleaseStream(Stream stream)
    {
        // No special handling required
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
            // HTML content to be converted
            string html = "<html><body><h1>Hello World</h1></body></html>";
            // Base URL (can be empty if not needed)
            string baseUrl = "";

            // Create HTML document from string
            HTMLDocument document = new HTMLDocument(html, baseUrl);

            // PDF conversion options
            PdfSaveOptions options = new PdfSaveOptions();

            // Custom stream provider to capture PDF in memory
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Perform conversion
                Converter.ConvertHTML(document, options, provider);

                // Retrieve the generated PDF stream
                MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;

                // Get PDF bytes
                byte[] pdfBytes = pdfStream.ToArray();

                Console.WriteLine($"PDF generated successfully. Size: {pdfBytes.Length} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}