// Write the PDF output of ConvertHTML directly to a MemoryStream for further processing without creating a temporary file.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            // Base URL for the document
            string baseUrl = "http://example.com";

            // Create an HTMLDocument from the string content
            HTMLDocument document = new HTMLDocument(html, baseUrl);

            // Configure PDF save options (default settings)
            PdfSaveOptions options = new PdfSaveOptions();

            // Use a custom stream provider to capture PDF output in memory
            using (MemoryStreamProvider streamProvider = new MemoryStreamProvider())
            {
                // Convert HTML to PDF, writing the result to the provider
                Converter.ConvertHTML(document, options, streamProvider);

                // Retrieve the generated PDF stream
                MemoryStream pdfStream = streamProvider.Streams[0];
                pdfStream.Position = 0;

                // Example processing: get PDF bytes and display size
                byte[] pdfBytes = pdfStream.ToArray();
                Console.WriteLine($"PDF generated, size: {pdfBytes.Length} bytes");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Custom ICreateStreamProvider implementation that stores streams in memory
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
            if (stream != null)
                stream.Flush();
        }

        public void Dispose()
        {
            foreach (var ms in Streams)
                ms.Dispose();
        }
    }
}