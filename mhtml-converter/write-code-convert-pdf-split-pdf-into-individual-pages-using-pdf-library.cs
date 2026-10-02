// Write code to convert PDF and then split the PDF into individual pages using a PDF library.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

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
            // Prepare sample HTML with page breaks to generate multiple PDF pages
            string htmlContent = "<html><body>" +
                                 "<div style='page-break-after:always;'>Page 1 content</div>" +
                                 "<div>Page 2 content</div>" +
                                 "</body></html>";

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set PDF save options (default options are sufficient)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Use custom stream provider to capture each page as a separate stream
            CustomStreamProvider provider = new CustomStreamProvider();

            // Convert HTML to PDF, streams will be created per page
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Ensure output directory exists
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Save each page stream to an individual PDF file
            for (int i = 0; i < provider.Streams.Count; i++)
            {
                MemoryStream pageStream = provider.Streams[i];
                pageStream.Position = 0;
                string pagePath = Path.Combine(outputDir, $"page_{i + 1}.pdf");
                using (FileStream fs = File.Create(pagePath))
                {
                    pageStream.CopyTo(fs);
                }
            }

            Console.WriteLine("PDF conversion and splitting completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}