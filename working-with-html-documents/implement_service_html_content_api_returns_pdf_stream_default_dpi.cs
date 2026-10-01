// Implement a service that receives HTML content via API and returns a PDF stream with default DPI.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUrl = "http://example.com";

            // Create HTML document from string
            var document = new Aspose.Html.HTMLDocument(html, baseUrl);

            // Set PDF save options (default options are sufficient)
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Use in‑memory provider to capture PDF output
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                if (provider.Streams.Count == 0)
                    throw new InvalidOperationException("No PDF stream was generated.");

                using (var pdfStream = provider.Streams[0])
                {
                    pdfStream.Position = 0;
                    byte[] pdfBytes = pdfStream.ToArray();

                    // Write PDF to file
                    string outputPath = "output.pdf";
                    File.WriteAllBytes(outputPath, pdfBytes);
                    Console.WriteLine($"PDF successfully saved to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}