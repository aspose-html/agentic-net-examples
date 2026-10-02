// Convert HTML to PNG and compress the resulting file using GZip stream before saving to disk.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

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
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            var provider = new MemoryStreamProvider();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            if (provider.Streams.Count > 0)
            {
                var pngStream = provider.Streams[0];
                pngStream.Position = 0;
                string outputPath = "output.png.gz";

                using (var fileStream = File.Create(outputPath))
                using (var gzipStream = new GZipStream(fileStream, CompressionMode.Compress))
                {
                    pngStream.CopyTo(gzipStream);
                }

                Console.WriteLine("Compressed PNG saved to " + outputPath);
            }
            else
            {
                Console.WriteLine("No PNG streams were generated.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}