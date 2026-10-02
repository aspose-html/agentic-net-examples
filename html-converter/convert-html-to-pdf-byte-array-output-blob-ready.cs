// Convert HTML to PDF and produce byte[] output (BLOB-ready)

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var s in Streams)
        {
            s.Dispose();
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, PDF!</h1></body></html>";
            string baseUrl = "about:blank";

            // Load HTML content
            var document = new Aspose.Html.HTMLDocument(html, baseUrl);

            // Set PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Use in-memory provider to capture PDF bytes
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                if (provider.Streams.Count > 0)
                {
                    MemoryStream pdfStream = provider.Streams[0];
                    pdfStream.Position = 0;
                    byte[] pdfBytes = pdfStream.ToArray();

                    Console.WriteLine($"PDF generated successfully. Byte array length: {pdfBytes.Length}");
                    // Optional: write to file for verification
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
                    File.WriteAllBytes(outputPath, pdfBytes);
                    Console.WriteLine($"PDF saved to: {outputPath}");
                }
                else
                {
                    Console.WriteLine("No PDF stream was generated.");
                }
            }

            // Clean up
            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}