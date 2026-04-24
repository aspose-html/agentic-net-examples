// Convert an EPUB file to PDF using using statements to ensure FileStream resources are disposed.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.IO;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input EPUB and output PDF
            string inputPath = "input.epub";
            string outputPath = "output.pdf";

            // Open the EPUB file with a using statement to ensure disposal
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Create default PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Custom stream provider to capture the PDF output in memory
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to PDF, writing the result to the provider
                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Retrieve the first generated memory stream (the PDF)
                    MemoryStream resultStream = provider.GetFirstStream();
                    resultStream.Position = 0;

                    // Write the PDF memory stream to a file using a using statement
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        resultStream.CopyTo(fileStream);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Custom implementation of ICreateStreamProvider that stores streams in a list
    class MemoryStreamProvider : ICreateStreamProvider, IDisposable
    {
        private readonly List<MemoryStream> _streams = new List<MemoryStream>();

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
            // No additional actions required for memory streams
        }

        // Helper to retrieve the first generated stream
        public MemoryStream GetFirstStream()
        {
            return _streams.Count > 0 ? _streams[0] : null;
        }

        // Dispose all stored memory streams
        public void Dispose()
        {
            foreach (var ms in _streams)
                ms.Dispose();
        }
    }
}