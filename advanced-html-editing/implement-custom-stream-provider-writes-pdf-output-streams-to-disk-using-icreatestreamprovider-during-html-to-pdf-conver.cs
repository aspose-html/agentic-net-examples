// Implement a custom stream provider that writes PDF output streams to disk using ICreateStreamProvider during HTML to PDF conversion.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class DiskStreamProvider : ICreateStreamProvider, IDisposable
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

    public string OutputPath => _outputPath;
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
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            HTMLDocument document = new HTMLDocument(inputPath);
            PdfSaveOptions options = new PdfSaveOptions();

            DiskStreamProvider provider = new DiskStreamProvider(outputPath);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            if (provider.Streams.Count > 0)
            {
                MemoryStream pdfStream = provider.Streams[0];
                pdfStream.Position = 0;
                using (FileStream fileStream = new FileStream(provider.OutputPath, FileMode.Create, FileAccess.Write))
                {
                    pdfStream.CopyTo(fileStream);
                }
                Console.WriteLine($"PDF saved to: {provider.OutputPath}");
            }
            else
            {
                Console.WriteLine("No PDF stream was generated.");
            }

            provider.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}