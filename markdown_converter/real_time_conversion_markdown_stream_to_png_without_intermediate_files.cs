// Perform real‑time conversion of a Markdown stream to PNG format without writing intermediate files.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int index)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No additional handling required.
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
    }

    public MemoryStream GetFirstStream()
    {
        return _streams.FirstOrDefault();
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: <markdownFilePath> <outputPngPath>");
                return;
            }

            string markdownPath = args[0];
            string outputPath = args[1];

            using var markdownStream = File.OpenRead(markdownPath);
            HTMLDocument document = Converter.ConvertMarkdown(markdownStream, "");

            ImageSaveOptions options = new ImageSaveOptions();

            using var provider = new MemoryStreamProvider();
            Converter.ConvertHTML(document, options, provider);

            MemoryStream imageStream = provider.GetFirstStream();
            if (imageStream != null)
            {
                imageStream.Position = 0;
                using var fileStream = File.Create(outputPath);
                imageStream.CopyTo(fileStream);
            }
            else
            {
                Console.WriteLine("No image stream was generated.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}