// Convert an EPUB file to PDF and return the result as a MemoryStream.

using System;
using System.IO;
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

    public void ReleaseStream(Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
        }
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
    }

    public Stream GetFirstStream()
    {
        return Streams.Count > 0 ? Streams[0] : null;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                var firstStream = provider.GetFirstStream() as MemoryStream;
                if (firstStream != null)
                {
                    firstStream.Position = 0;
                    var resultStream = new MemoryStream(firstStream.ToArray());
                    Console.WriteLine($"PDF generated. Size: {resultStream.Length} bytes.");
                }
                else
                {
                    Console.WriteLine("No PDF stream was generated.");
                }

                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}