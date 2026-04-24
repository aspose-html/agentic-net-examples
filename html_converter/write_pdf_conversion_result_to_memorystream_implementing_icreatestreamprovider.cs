// Write PDF conversion result to a MemoryStream by implementing ICreateStreamProvider interface.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

namespace EpubToPdfMemory
{
    // Custom stream provider that stores created MemoryStream instances
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
            // No special handling required
        }

        public void Dispose()
        {
            foreach (var ms in Streams)
                ms.Dispose();
        }

        // Helper to retrieve the first generated stream
        public MemoryStream GetFirstStream()
        {
            return Streams.Count > 0 ? Streams[0] : null;
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

                // Open the EPUB file as a read-only stream
                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    // Configure PDF save options (default settings)
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Create the custom stream provider
                    using (MemoryStreamProvider provider = new MemoryStreamProvider())
                    {
                        // Convert EPUB to PDF, output will be written to the provider's stream
                        Converter.ConvertEPUB(epubStream, options, provider);

                        // Retrieve the generated PDF as a MemoryStream
                        MemoryStream resultStream = new MemoryStream(provider.GetFirstStream().ToArray());
                        resultStream.Position = 0;

                        // Example usage: write the PDF bytes to console length
                        Console.WriteLine($"PDF generated, size: {resultStream.Length} bytes");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}