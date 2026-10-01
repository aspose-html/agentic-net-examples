// Write code to convert HTML to DOCX and return the result as a byte array for APIs.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

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
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";

            // Create HTML document from string
            HTMLDocument document = new HTMLDocument(htmlContent);

            // Set up DOCX save options
            DocSaveOptions saveOptions = new DocSaveOptions();

            // Create in-memory stream provider
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Convert HTML to DOCX using the provider
                Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, provider);

                // Retrieve the generated DOCX as a byte array
                if (provider.Streams.Count > 0)
                {
                    MemoryStream memory = provider.Streams[0];
                    memory.Seek(0, SeekOrigin.Begin);
                    byte[] docxBytes = memory.ToArray();

                    // For demonstration, write the byte array to a file
                    string outputPath = "output.docx";
                    File.WriteAllBytes(outputPath, docxBytes);
                    Console.WriteLine($"DOCX file generated successfully. Size: {docxBytes.Length} bytes.");
                }
                else
                {
                    Console.WriteLine("No output streams were generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}