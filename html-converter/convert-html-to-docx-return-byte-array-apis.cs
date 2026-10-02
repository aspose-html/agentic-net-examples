// Write code to convert HTML to DOCX and return the result as a byte array for APIs.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>";

            // Create HTMLDocument from string content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set up DOCX save options
            var saveOptions = new Aspose.Html.Saving.DocSaveOptions();

            // Provider to capture output in memory
            using (var provider = new MemoryStreamProvider())
            {
                // Convert HTML to DOCX using the provider
                Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, provider);

                // Retrieve the generated DOCX as byte array
                MemoryStream memory = provider.Streams.First() as MemoryStream;
                memory.Seek(0, SeekOrigin.Begin);
                byte[] docxBytes = memory.ToArray();

                // Optional: write to a file for verification
                File.WriteAllBytes("output.docx", docxBytes);

                Console.WriteLine("Conversion successful. DOCX byte array length: " + docxBytes.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}