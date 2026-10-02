// Implement ICreateStreamProvider to supply file streams for multi‑page HTML to JPEG conversion.

using System;
using System.IO;
using System.Collections.Generic;

sealed class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams = new List<MemoryStream>();

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
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><style>div{page-break-after:always;}</style></head><body><div>Page 1</div><div>Page 2</div></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
                Directory.CreateDirectory(outputDir);

                for (int i = 0; i < provider.Streams.Count; i++)
                {
                    var stream = provider.Streams[i];
                    stream.Position = 0;
                    string outPath = Path.Combine(outputDir, $"page_{i + 1}.jpg");
                    using (var fileStream = File.Create(outPath))
                    {
                        stream.CopyTo(fileStream);
                    }
                }

                provider.Dispose();
            }

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}