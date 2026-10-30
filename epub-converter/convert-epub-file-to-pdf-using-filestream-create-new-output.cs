// Convert an EPUB file to PDF by writing the output using FileStream with create‑new mode.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

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
        if (stream != null)
        {
            stream.Flush();
        }
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.pdf";

            // Ensure input file exists (for demonstration, create an empty file if missing)
            if (!File.Exists(inputPath))
            {
                using (FileStream fs = File.Create(inputPath))
                {
                    // Empty EPUB placeholder
                }
            }

            Stream epubStream = File.OpenRead(inputPath);
            PdfSaveOptions options = new PdfSaveOptions();
            MemoryStreamProvider provider = new MemoryStreamProvider();

            Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

            if (provider.Streams.Count > 0)
            {
                MemoryStream resultStream = provider.Streams[0];
                resultStream.Position = 0;
                using (FileStream fileStream = new FileStream(outputPath, FileMode.CreateNew, FileAccess.Write))
                {
                    resultStream.CopyTo(fileStream);
                }
                Console.WriteLine("EPUB successfully converted to PDF: " + outputPath);
            }
            else
            {
                Console.WriteLine("No output stream was generated.");
            }

            epubStream.Dispose();
            provider.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}