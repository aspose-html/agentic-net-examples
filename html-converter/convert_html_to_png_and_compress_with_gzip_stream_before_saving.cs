// Convert HTML to PNG and compress the resulting file using GZip stream before saving to disk.

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html;

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
        Streams.Clear();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Create HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, ".");

            // Configure image save options for PNG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Use custom stream provider to capture output in memory
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                if (provider.Streams.Count > 0)
                {
                    var pngStream = provider.Streams[0];
                    pngStream.Position = 0;

                    // Define output path for compressed file
                    string outputPath = "output.png.gz";

                    // Compress PNG data using GZip and save to disk
                    using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    using (var gzipStream = new GZipStream(fileStream, CompressionMode.Compress))
                    {
                        pngStream.CopyTo(gzipStream);
                    }

                    Console.WriteLine("HTML converted to PNG and compressed successfully: " + outputPath);
                }
                else
                {
                    Console.WriteLine("No PNG stream was generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}