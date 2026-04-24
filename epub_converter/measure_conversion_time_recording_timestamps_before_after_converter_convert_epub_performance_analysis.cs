// Measure conversion time by recording timestamps before and after calling Converter.ConvertEPUB for performance analysis.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    // Stores all created memory streams
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    // Called by the converter to obtain a stream for output
    public Stream GetStream(string path, string contentType)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Overload with buffer size (not used, but required by the interface)
    public Stream GetStream(string path, string contentType, int bufferSize)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    // Called when the converter is done with a stream
    public void ReleaseStream(Stream stream)
    {
        // No special handling needed; streams are kept for later use
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
        try
        {
            // Input EPUB file and output XPS file paths
            string inputPath = "sample.epub";
            string outputPath = "output.xps";

            // Open the EPUB file as a read‑only stream
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Prepare conversion options
                XpsSaveOptions options = new XpsSaveOptions();

                // Create the custom stream provider
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Record start time
                    DateTime start = DateTime.Now;

                    // Perform the conversion
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Record end time
                    DateTime end = DateTime.Now;
                    TimeSpan elapsed = end - start;

                    // Write the first generated XPS stream to the output file
                    if (provider.Streams.Count > 0)
                    {
                        provider.Streams[0].Position = 0; // reset position before reading
                        using (FileStream fileOut = File.Create(outputPath))
                        {
                            provider.Streams[0].CopyTo(fileOut);
                        }
                    }

                    // Report elapsed time
                    Console.WriteLine($"EPUB to XPS conversion took {elapsed.TotalMilliseconds} ms.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}