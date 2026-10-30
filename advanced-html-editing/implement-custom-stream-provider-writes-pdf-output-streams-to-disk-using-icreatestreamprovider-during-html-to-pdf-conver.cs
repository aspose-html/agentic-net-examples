// Implement a custom stream provider that writes PDF output streams to disk using ICreateStreamProvider during HTML to PDF conversion.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class DiskStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly string _outputPath;
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public DiskStreamProvider(string outputPath)
    {
        _outputPath = outputPath;
    }

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
        // No action needed; streams will be flushed when written to disk.
    }

    public void Dispose()
    {
        foreach (MemoryStream ms in Streams)
        {
            ms.Dispose();
        }
    }

    public void WriteToFile()
    {
        if (Streams.Count == 0)
            return;

        MemoryStream pdfStream = Streams[0];
        pdfStream.Position = 0;
        using (FileStream fileStream = new FileStream(_outputPath, FileMode.Create, FileAccess.Write))
        {
            pdfStream.CopyTo(fileStream);
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputPath, html, Encoding.UTF8);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            DiskStreamProvider provider = new DiskStreamProvider(outputPath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
            provider.WriteToFile();

            Console.WriteLine("PDF conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}