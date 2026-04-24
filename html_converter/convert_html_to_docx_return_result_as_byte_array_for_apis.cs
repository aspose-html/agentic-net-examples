// Write code to convert HTML to DOCX and return the result as a byte array for APIs.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<Stream> Streams { get; } = new List<Stream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int index)
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
        foreach (var s in Streams)
        {
            s.Dispose();
        }
        Streams.Clear();
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content; replace with actual input as needed
            string htmlContent = "<html><body><h1>Hello, Aspose!</h1></body></html>";
            string baseUri = "http://example.com/";

            // Create HTML document from string
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Configure DOCX save options (default settings)
            DocSaveOptions options = new DocSaveOptions();

            // Provider to capture output in memory
            using (var provider = new MemoryStreamProvider())
            {
                // Perform conversion
                Converter.ConvertHTML(document, options, provider);

                // Retrieve the generated DOCX bytes
                MemoryStream memory = (MemoryStream)provider.Streams.First();
                memory.Seek(0, SeekOrigin.Begin);
                byte[] docxBytes = memory.ToArray();

                // Example usage: write to a file (optional)
                File.WriteAllBytes("output.docx", docxBytes);

                Console.WriteLine($"Conversion successful. Byte array length: {docxBytes.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}