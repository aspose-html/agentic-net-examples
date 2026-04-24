// Convert an EPUB file to PDF and return the result as a MemoryStream.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        stream?.Flush();
    }

    public MemoryStream GetFirstStream()
    {
        return Streams.Count > 0 ? Streams[0] : null;
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
            // Path to the source EPUB file
            string epubPath = "sample.epub";

            // Open the EPUB file as a stream
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                // Configure PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Create the custom stream provider to capture output in memory
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Perform the conversion
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Retrieve the generated PDF as a MemoryStream
                    MemoryStream pdfStream = new MemoryStream(provider.GetFirstStream().ToArray());
                    pdfStream.Position = 0;

                    // Example usage: write the PDF to a file (optional)
                    using (FileStream file = new FileStream("output.pdf", FileMode.Create, FileAccess.Write))
                    {
                        pdfStream.CopyTo(file);
                    }

                    Console.WriteLine($"Conversion succeeded. PDF size: {pdfStream.Length} bytes.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}