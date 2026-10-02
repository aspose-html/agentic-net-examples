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
        // No action needed for in-memory streams
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
            string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            byte[] pdfBytes = ConvertHtmlToPdf(html);
            // Save to file for demonstration purposes
            string outputPath = "output.pdf";
            File.WriteAllBytes(outputPath, pdfBytes);
            Console.WriteLine($"PDF generated successfully: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] ConvertHtmlToPdf(string htmlContent)
    {
        // Base URI can be a placeholder since there are no external resources
        string baseUri = "about:blank";

        using (var document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
        {
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
                if (provider.Streams.Count == 0)
                    throw new InvalidOperationException("No PDF stream was generated.");

                MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                return pdfStream.ToArray();
            }
        }
    }
}