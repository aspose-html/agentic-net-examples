// Use MemoryStream to convert a Markdown string to PDF without creating intermediate files on disk.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html;
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
            // Sample markdown content
            string markdown = "# Sample Title\n\nThis is a **markdown** text.\n\n- Item 1\n- Item 2";

            // Convert markdown string to a memory stream (UTF-8)
            MemoryStream htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));

            // Load the markdown (treated as HTML) into an HTMLDocument
            HTMLDocument document = new HTMLDocument(htmlStream, "about:blank");

            // Set PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // In‑memory stream provider for PDF output
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Retrieve the generated PDF stream
                MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;

                // Save PDF to a file (optional, demonstrates the result)
                using (FileStream file = File.Create("markdown.pdf"))
                {
                    pdfStream.CopyTo(file);
                }

                Console.WriteLine("PDF conversion completed successfully. Output saved to 'markdown.pdf'.");
            }

            // Clean up
            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}