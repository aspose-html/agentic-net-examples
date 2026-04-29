// Use a using block to ensure FileStream disposal after writing converted XPS data to disk.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string contentType)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string contentType, int bufferSize)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        if (stream != null)
        {
            stream.Position = 0;
        }
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
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
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output XPS file path
            string outputPath = "output.xps";

            // Open the EPUB file as a stream
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Initialize XPS save options
                XpsSaveOptions options = new XpsSaveOptions();

                // Create the custom stream provider to capture XPS output in memory
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Perform the conversion
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Retrieve the generated XPS stream
                    MemoryStream xpsStream = provider.Streams[0];
                    xpsStream.Position = 0;

                    // Write the XPS data to a file using a using block for disposal
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.CreateNew, FileAccess.Write))
                    {
                        xpsStream.CopyTo(fileStream);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}