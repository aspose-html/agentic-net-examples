// Batch convert a mixed collection of HTML and MHTML files to PDF, preserving original filenames.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(inputFolder);
            foreach (string filePath in files)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                string outputPath = Path.ChangeExtension(filePath, ".pdf");
                if (extension == ".mhtml" || extension == ".mht")
                {
                    // Convert MHTML to PDF
                    System.IO.FileStream stream = System.IO.File.OpenRead(filePath);
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                    stream.Dispose();
                }
                else if (extension == ".html" || extension == ".htm")
                {
                    // Convert HTML to PDF using a custom memory stream provider
                    string htmlContent = File.ReadAllText(filePath);
                    string baseUri = Path.GetDirectoryName(filePath);
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    var provider = new MemoryStreamProvider();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
                    if (provider.Streams.Count > 0)
                    {
                        MemoryStream memory = provider.Streams[0];
                        memory.Position = 0;
                        using (FileStream fs = File.Create(outputPath))
                        {
                            memory.CopyTo(fs);
                        }
                    }
                    provider.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Simple memory stream provider for Aspose.HTML conversions
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