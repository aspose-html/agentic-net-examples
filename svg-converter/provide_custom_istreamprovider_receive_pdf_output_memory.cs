// Provide a custom ICreateStreamProvider to receive PDF output in memory.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
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
        // No action needed for in‑memory streams
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
            // Sample HTML content
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUrl = "http://example.com/";

            // Create HTML document from string
            HTMLDocument document = new HTMLDocument(html, baseUrl);

            // Set PDF save options (default options are sufficient)
            PdfSaveOptions options = new PdfSaveOptions();

            // Use custom provider to capture PDF in memory
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                if (provider.Streams.Count == 0)
                {
                    Console.WriteLine("No PDF stream was generated.");
                    return;
                }

                MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                byte[] pdfBytes = pdfStream.ToArray();

                // Write PDF to a file for verification
                string outputPath = "output.pdf";
                File.WriteAllBytes(outputPath, pdfBytes);
                Console.WriteLine($"PDF successfully generated and saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}