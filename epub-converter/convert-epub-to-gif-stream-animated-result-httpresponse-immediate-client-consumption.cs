// Convert EPUB to GIF and stream the animated result through an HttpResponse for immediate client consumption.

using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using Aspose.Html.IO;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // Intentionally left empty to keep streams available for later reading.
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
    }

    public System.Collections.Generic.IReadOnlyList<System.IO.MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "sample.epub";

            // Create a placeholder EPUB file if it does not exist.
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (FileStream epubFileStream = File.OpenRead(epubPath))
            using (MemoryStream epubMemory = new MemoryStream())
            {
                epubFileStream.CopyTo(epubMemory);
                epubMemory.Position = 0;

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubMemory, options, provider);

                    if (provider.Streams.Count > 0)
                    {
                        MemoryStream gifStream = provider.Streams[0];
                        gifStream.Position = 0;

                        HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                        response.Content = new ByteArrayContent(gifStream.ToArray());
                        response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/gif");

                        Console.WriteLine("HTTP response prepared with GIF content. Length: " + response.Content.Headers.ContentLength);
                    }
                    else
                    {
                        Console.WriteLine("No GIF stream was generated.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}