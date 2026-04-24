// Convert an EPUB file to PDF by writing the output using FileStream with create‑new mode.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;

namespace EpubToPdfExample
{
    // Custom stream provider that stores generated streams in memory
    public class MemoryStreamProvider : ICreateStreamProvider, IDisposable
    {
        // List to keep all created memory streams
        public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

        // Called by the converter to obtain an output stream (without index)
        public Stream GetStream(string path, string mime)
        {
            var ms = new MemoryStream();
            Streams.Add(ms);
            return ms;
        }

        // Called by the converter to obtain an output stream (with index)
        public Stream GetStream(string path, string mime, int index)
        {
            // For simplicity, ignore index and behave like the other overload
            return GetStream(path, mime);
        }

        // Called when the converter releases a stream; we keep it for later use
        public void ReleaseStream(Stream stream)
        {
            // No action needed; streams are retained in the list
        }

        // Dispose all stored memory streams
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
        static void Main()
        {
            try
            {
                // Paths for input EPUB and output PDF
                string epubPath = "input.epub";
                string pdfPath = "output.pdf";

                // Open the EPUB file as a read‑only stream
                using var epubStream = File.OpenRead(epubPath);

                // Create PDF save options (default configuration)
                var pdfOptions = new PdfSaveOptions();

                // Instantiate the custom memory stream provider
                using var provider = new MemoryStreamProvider();

                // Perform the conversion: EPUB -> PDF (output goes to provider)
                Converter.ConvertEPUB(epubStream, pdfOptions, provider);

                // Retrieve the first generated PDF stream
                var resultStream = provider.Streams[0];
                resultStream.Position = 0; // Ensure we read from the beginning

                // Write the PDF data to a file using FileMode.CreateNew
                using var fileStream = new FileStream(pdfPath, FileMode.CreateNew, FileAccess.Write);
                resultStream.CopyTo(fileStream);
            }
            catch (Exception ex)
            {
                // Output any errors that occur during conversion
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}