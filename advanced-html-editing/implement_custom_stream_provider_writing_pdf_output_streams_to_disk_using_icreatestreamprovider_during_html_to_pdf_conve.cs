// Implement a custom stream provider that writes PDF output streams to disk using ICreateStreamProvider during HTML to PDF conversion.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

class DiskStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly string _outputPath;
    private readonly List<System.IO.Stream> _streams = new List<System.IO.Stream>();

    public DiskStreamProvider(string outputPath)
    {
        _outputPath = outputPath;
    }

    public System.IO.Stream GetStream(string name, string extension)
    {
        var fileStream = new System.IO.FileStream(_outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
        _streams.Add(fileStream);
        return fileStream;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        // For simplicity, ignore page number and use the same output path.
        return GetStream(name, extension);
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
        }
    }

    public void Dispose()
    {
        foreach (var stream in _streams)
        {
            stream.Dispose();
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

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><h1>Hello, PDF!</h1></body></html>");
            }

            var document = new Aspose.Html.HTMLDocument(inputPath);
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            using (var provider = new DiskStreamProvider(outputPath))
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);
            }

            Console.WriteLine($"PDF successfully saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}