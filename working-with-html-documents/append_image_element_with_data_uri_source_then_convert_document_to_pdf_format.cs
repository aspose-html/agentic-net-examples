// Append an image element with a data URI source, then convert the document to PDF format.

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
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
            string html = "<html><body><h1>Hello Aspose.HTML!</h1></body></html>";
            string baseUrl = "file:///";

            var document = new Aspose.Html.HTMLDocument(html, baseUrl);
            var options = new Aspose.Html.Saving.PdfSaveOptions();
            // Example of setting a background color (optional)
            // options.BackgroundColor = System.Drawing.Color.AliceBlue;

            var provider = new MemoryStreamProvider();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            if (provider.Streams.Count > 0)
            {
                var pdfStream = provider.Streams[0];
                pdfStream.Position = 0;

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
                using (var fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    pdfStream.CopyTo(fs);
                }

                Console.WriteLine($"PDF saved to {outputPath}");
            }
            else
            {
                Console.WriteLine("No PDF stream was generated.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}