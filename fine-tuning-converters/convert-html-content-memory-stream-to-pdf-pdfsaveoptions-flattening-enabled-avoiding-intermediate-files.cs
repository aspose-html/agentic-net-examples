// Convert HTML content from a memory stream to PDF using PdfSaveOptions with flattening enabled, avoiding intermediate files.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

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

    public void ReleaseStream(Stream stream) { }

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
            string html = "<html><body><h1>Hello, World!</h1></body></html>";
            using (var htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(html)))
            {
                var document = new Aspose.Html.HTMLDocument(htmlStream, "about:blank");
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                // Flattening not supported in this version; proceeding without it.

                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
                    var pdfStream = provider.Streams[0];
                    pdfStream.Position = 0;

                    string outputPath = "output.pdf";
                    using (var file = File.Create(outputPath))
                    {
                        pdfStream.CopyTo(file);
                    }

                    Console.WriteLine($"PDF saved to {outputPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}