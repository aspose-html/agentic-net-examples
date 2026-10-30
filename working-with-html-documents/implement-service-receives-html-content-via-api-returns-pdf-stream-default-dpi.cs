// Implement a service that receives HTML content via API and returns a PDF stream with default DPI.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html;

class MyStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (MemoryStream ms in Streams)
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
            string html = "<html><body><h1>Hello, PDF!</h1></body></html>";
            string baseUrl = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUrl);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            using (MyStreamProvider provider = new MyStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                byte[] pdfBytes = pdfStream.ToArray();

                // Example: write the PDF to a file
                string outputPath = "output.pdf";
                File.WriteAllBytes(outputPath, pdfBytes);
                Console.WriteLine($"PDF generated successfully. Size: {pdfBytes.Length} bytes. Saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}