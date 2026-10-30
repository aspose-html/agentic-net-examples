// Write code to convert PDF and then split the PDF into individual pages using a PDF library.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class CustomStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        MemoryStream ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
        }
    }

    public void Dispose()
    {
        foreach (MemoryStream ms in Streams)
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
            // Prepare sample HTML content
            string htmlContent = "<html><body><h1>Page 1</h1><p>This is the first page.</p><div style='page-break-before:always;'></div><h1>Page 2</h1><p>This is the second page.</p></body></html>";
            string baseUri = "about:blank";

            // Create HTML document from content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Set PDF save options (default)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Use custom stream provider to capture each page as a separate stream
            CustomStreamProvider provider = new CustomStreamProvider();

            // Convert HTML to PDF with per-page streams
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Ensure output directory exists
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Save each page stream to a separate PDF file
            for (int i = 0; i < provider.Streams.Count; i++)
            {
                MemoryStream pageStream = provider.Streams[i];
                pageStream.Position = 0;
                string pagePath = Path.Combine(outputDir, $"page_{i + 1}.pdf");
                using (FileStream fs = File.Create(pagePath))
                {
                    pageStream.CopyTo(fs);
                }
                Console.WriteLine($"Saved page {i + 1} to: {pagePath}");
            }

            // Cleanup
            provider.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}