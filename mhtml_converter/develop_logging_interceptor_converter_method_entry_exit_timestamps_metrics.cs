// Develop a logging interceptor that records Converter method entry and exit timestamps for performance metrics.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    // Stores all created memory streams for later retrieval
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    // Called by the converter to obtain a stream for output
    public Stream GetStream(string path, string mimeType)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Overload with buffer size (not used, but required by the interface)
    public Stream GetStream(string path, string mimeType, int bufferSize)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Called when the converter is done with a stream
    public void ReleaseStream(Stream stream)
    {
        // No special handling needed for MemoryStream
    }

    // Dispose all stored streams
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
    static void Main(string[] args)
    {
        // Adjust these paths as needed or pass via command‑line arguments
        string epubPath = "sample.epub";
        string outputPath = "output.xps";

        try
        {
            // Load the EPUB file into a stream
            System.IO.Stream stream = System.IO.File.OpenRead(epubPath);

            // Prepare conversion options
            XpsSaveOptions options = new XpsSaveOptions();

            // Create a custom stream provider that captures the output in memory
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Record start time
                DateTime start = DateTime.Now;

                // Perform the conversion
                Converter.ConvertEPUB(stream, options, provider);

                // Record end time
                DateTime end = DateTime.Now;
                TimeSpan elapsed = end - start;

                // Write the first generated memory stream to the output file
                if (provider.Streams.Count > 0)
                {
                    provider.Streams[0].Position = 0; // Reset position before copying
                    using (FileStream file = File.Create(outputPath))
                    {
                        provider.Streams[0].CopyTo(file);
                    }
                }

                Console.WriteLine($"Conversion completed in {elapsed.TotalMilliseconds} ms.");
                Console.WriteLine($"Output written to: {outputPath}");
            }

            // Clean up the input stream
            stream.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}