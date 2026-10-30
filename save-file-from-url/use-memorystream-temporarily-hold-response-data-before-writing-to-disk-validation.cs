// Use a MemoryStream to temporarily hold the response data before writing to disk for validation.

using System;
using System.IO;
using System.Collections.Generic;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> streams = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream) { }

    public void Dispose()
    {
        foreach (var s in streams)
            s.Dispose();
    }

    public List<MemoryStream> Streams => streams;
}

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            using (var provider = new MemoryStreamProvider())
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                var resultStream = provider.Streams[0];
                resultStream.Position = 0;

                string outputPath = "output.pdf";
                using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    resultStream.CopyTo(fileStream);
                }

                Console.WriteLine($"PDF saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}