// Use a MemoryStream to temporarily hold the response data before writing to disk for validation.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file path
            string htmlPath = "input.html";
            // Desired output PDF file path
            string outputPath = "output.pdf";

            // Create a custom stream provider that stores output in memory
            var provider = new MemoryStreamProvider();

            // Set conversion options (PDF)
            var options = new PdfSaveOptions();

            // Perform conversion, result will be written to the provider's stream
            Converter.ConvertHTML(htmlPath, options, provider);

            // Retrieve the first generated in‑memory stream and write it to disk
            MemoryStream resultStream = provider.Streams[0];
            resultStream.Position = 0;
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                resultStream.CopyTo(fileStream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom ICreateStreamProvider implementation that keeps streams in memory
class MemoryStreamProvider : ICreateStreamProvider
{
    // Expose stored streams for later retrieval
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

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
        // No action needed for in‑memory streams
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