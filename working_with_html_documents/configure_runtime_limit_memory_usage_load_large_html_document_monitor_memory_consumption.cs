// Configure runtime to limit memory usage, load a large HTML document, and monitor memory consumption.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public System.Collections.Generic.List<MemoryStream> Streams { get; } = new System.Collections.Generic.List<MemoryStream>();

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
            stream.Flush();
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
            ms.Dispose();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Path to a large HTML file
            string htmlPath = "large.html";

            // Monitor memory before loading
            long memoryBeforeLoad = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory before loading: {memoryBeforeLoad / (1024 * 1024)} MB");

            // Create a configuration (no explicit memory limit property in current API)
            var config = new Configuration();

            // Load the large HTML document
            var document = new HTMLDocument(htmlPath, config);

            // Monitor memory after loading
            long memoryAfterLoad = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory after loading: {memoryAfterLoad / (1024 * 1024)} MB");
            Console.WriteLine($"Memory used for loading: {(memoryAfterLoad - memoryBeforeLoad) / (1024 * 1024)} MB");

            // Convert the document to PDF in memory using a custom stream provider
            var pdfOptions = new PdfSaveOptions();
            using var provider = new MemoryStreamProvider();
            Converter.ConvertHTML(document, pdfOptions, provider);

            // Access the generated PDF stream
            if (provider.Streams.Count > 0)
            {
                var pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                // Optionally, write the PDF to a file for verification
                using var file = File.Create("output.pdf");
                pdfStream.CopyTo(file);
            }

            // Monitor memory after conversion
            long memoryAfterConversion = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory after conversion: {memoryAfterConversion / (1024 * 1024)} MB");
            Console.WriteLine($"Additional memory used for conversion: {(memoryAfterConversion - memoryAfterLoad) / (1024 * 1024)} MB");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}