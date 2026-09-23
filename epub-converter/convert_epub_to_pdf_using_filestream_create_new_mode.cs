// Convert an EPUB file to PDF by writing the output using FileStream with create‑new mode.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MyStreamProvider : Aspose.Html.IO.ICreateStreamProvider
{
    public List<MemoryStream> Streams = new List<MemoryStream>();

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
            string inputPath = "sample.epub";
            string outputPath = Path.Combine("output", "result.pdf");

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open EPUB file stream
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Prepare PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Create custom stream provider
                MyStreamProvider provider = new MyStreamProvider();

                // Convert EPUB to PDF using the provider
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                // Retrieve the generated PDF stream
                if (provider.Streams.Count > 0)
                {
                    MemoryStream resultStream = provider.Streams[0];
                    resultStream.Position = 0;

                    // Write the PDF to a file using FileMode.CreateNew
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.CreateNew, FileAccess.Write))
                    {
                        resultStream.CopyTo(fileStream);
                    }

                    Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPath);
                }
                else
                {
                    Console.WriteLine("No output stream was generated.");
                }

                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}