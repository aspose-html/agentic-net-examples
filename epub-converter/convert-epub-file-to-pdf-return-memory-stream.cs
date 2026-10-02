// Convert an EPUB file to PDF and return the result as a MemoryStream.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        {
            stream.Flush();
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
            // Input EPUB file path (replace with an actual file path as needed)
            string epubPath = "sample.epub";

            // Ensure the input file exists; for demonstration, create an empty placeholder if missing
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                // Set PDF save options
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

                // Create the custom stream provider to capture output in memory
                using (var provider = new MemoryStreamProvider())
                {
                    // Perform the conversion
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, pdfOptions, provider);

                    // Retrieve the generated PDF stream
                    if (provider.Streams.Count == 0)
                    {
                        Console.WriteLine("No output streams were generated.");
                        return;
                    }

                    MemoryStream generatedPdf = provider.Streams[0];
                    generatedPdf.Position = 0;

                    // Copy to a new MemoryStream to return as the result
                    MemoryStream resultStream = new MemoryStream();
                    generatedPdf.CopyTo(resultStream);
                    resultStream.Position = 0;

                    // Example usage: display the size of the PDF in bytes
                    Console.WriteLine($"PDF generated successfully. Size: {resultStream.Length} bytes.");

                    // Dispose the result stream when done (optional here as program ends)
                    resultStream.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}