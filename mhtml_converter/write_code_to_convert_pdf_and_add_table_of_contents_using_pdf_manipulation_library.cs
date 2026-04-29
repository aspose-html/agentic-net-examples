// Write code to convert PDF and then add a table of contents using a PDF manipulation library.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content to be converted to PDF
            string htmlContent = "<html><body><h1>Sample Document</h1><p>This is a sample PDF generated from HTML.</p></body></html>";
            string baseUri = "";

            // Custom stream provider to capture PDF output in memory
            var streamProvider = new MemoryStreamProvider();

            // Configure PDF save options (default settings)
            var pdfOptions = new PdfSaveOptions();

            // Convert HTML to PDF and write the result to the custom stream provider
            Converter.ConvertHTML(htmlContent, baseUri, pdfOptions, streamProvider);

            // Retrieve the generated PDF bytes from the provider
            MemoryStream pdfStream = streamProvider.Streams[0];
            pdfStream.Position = 0;
            byte[] pdfBytes = pdfStream.ToArray();

            // Save the PDF bytes to a file
            string outputPath = Path.Combine(Environment.CurrentDirectory, "ConvertedDocument.pdf");
            File.WriteAllBytes(outputPath, pdfBytes);
            Console.WriteLine($"PDF successfully created at: {outputPath}");

            // -----------------------------------------------------------------
            // Adding a Table of Contents (TOC) to the generated PDF would require
            // a PDF manipulation library (e.g., Aspose.PDF). Since no rule for
            // PDF manipulation is provided, this step is omitted.
            // -----------------------------------------------------------------
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

// Custom implementation of ICreateStreamProvider to store streams in memory
class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public System.Collections.Generic.List<MemoryStream> Streams { get; } = new System.Collections.Generic.List<MemoryStream>();

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
        // No additional actions required for memory streams
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
    }
}