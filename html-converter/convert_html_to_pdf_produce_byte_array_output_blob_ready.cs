// Convert HTML to PDF and produce byte[] output (BLOB-ready)

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public System.Collections.Generic.List<System.IO.MemoryStream> Streams { get; } = new System.Collections.Generic.List<System.IO.MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new System.IO.MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new System.IO.MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var s in Streams)
        {
            s.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, PDF!</h1></body></html>";
            string baseUrl = "";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            MemoryStreamProvider provider = new MemoryStreamProvider();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            if (provider.Streams.Count == 0)
                throw new InvalidOperationException("No PDF stream was generated.");

            System.IO.MemoryStream pdfStream = provider.Streams[0];
            pdfStream.Position = 0;
            byte[] pdfBytes = pdfStream.ToArray();

            // Optional: write to file to verify output
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
            System.IO.File.WriteAllBytes(outputPath, pdfBytes);

            Console.WriteLine("PDF conversion successful. Byte array length: " + pdfBytes.Length);
            Console.WriteLine("PDF saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during HTML to PDF conversion: " + ex.Message);
        }
    }
}