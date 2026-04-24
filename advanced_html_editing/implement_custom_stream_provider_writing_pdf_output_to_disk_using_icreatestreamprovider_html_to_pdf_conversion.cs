// Implement a custom stream provider that writes PDF output streams to disk using ICreateStreamProvider during HTML to PDF conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.IO;

class DiskStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly string _outputPath;
    private FileStream _stream;

    public DiskStreamProvider(string outputPath)
    {
        _outputPath = outputPath;
    }

    public Stream GetStream(string name, string extension)
    {
        _stream = new FileStream(_outputPath, FileMode.Create, FileAccess.Write);
        return _stream;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        return GetStream(name, extension);
    }

    public void ReleaseStream(Stream stream)
    {
        // No additional actions required
    }

    public void Dispose()
    {
        _stream?.Dispose();
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
                File.WriteAllText(inputPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            HTMLDocument document = new HTMLDocument(inputPath);
            PdfSaveOptions options = new PdfSaveOptions();

            using (var provider = new DiskStreamProvider(outputPath))
            {
                Converter.ConvertHTML(document, options, provider);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}