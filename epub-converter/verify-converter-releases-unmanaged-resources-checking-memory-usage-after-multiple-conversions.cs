// Verify that the Converter object releases unmanaged resources by checking memory usage after multiple conversions.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Html.IO;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        if (stream != null)
        {
            stream.Flush();
        }
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
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            byte[] htmlBytes = Encoding.UTF8.GetBytes(htmlContent);
            using (MemoryStream htmlStream = new MemoryStream(htmlBytes))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlStream, "about:blank");
                const int iterations = 5;
                long baseline = GC.GetTotalMemory(true);
                Console.WriteLine($"Baseline memory: {baseline} bytes");
                for (int i = 0; i < iterations; i++)
                {
                    MemoryStreamProvider provider = new MemoryStreamProvider();
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
                    MemoryStream resultStream = provider.Streams[0];
                    resultStream.Position = 0;
                    // Optionally process resultStream here
                    provider.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    long currentMemory = GC.GetTotalMemory(true);
                    Console.WriteLine($"Iteration {i + 1}, total memory: {currentMemory} bytes");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}