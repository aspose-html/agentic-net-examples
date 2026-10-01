// Use MemoryStream to convert a Markdown string to PDF without creating intermediate files on disk.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html;

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
            string markdown = "# Sample Title\nThis is a **markdown** document converted to PDF using Aspose.HTML.";

            // Create an HTMLDocument from the markdown string (treated as HTML for this example)
            HTMLDocument document = new HTMLDocument(markdown, string.Empty);

            // Set PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Use custom stream provider to capture PDF in memory
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Retrieve the generated PDF stream
                MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;

                // Save PDF to a file (optional, demonstrates how to use the in‑memory result)
                string outputPath = "output.pdf";
                using (FileStream file = File.Create(outputPath))
                {
                    pdfStream.CopyTo(file);
                }

                Console.WriteLine($"PDF successfully generated and saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}