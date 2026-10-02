// Perform a one‑line static conversion of HTML string to JPEG using static Converter method and output location.

using System;
using System.IO;
using System.Collections.Generic;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        // No action needed; streams are retained for later use.
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
    static void Main()
    {
        try
        {
            string htmlContent = "<h1>Convert HTML to JPG File Format!</h1>";
            string baseUri = ".";

            var document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            var provider = new MemoryStreamProvider();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            if (provider.Streams.Count == 0)
                throw new InvalidOperationException("No output streams were generated.");

            var memoryStream = provider.Streams[0];
            memoryStream.Seek(0, SeekOrigin.Begin);

            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "stream-provider.jpg");

            using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                memoryStream.CopyTo(fileStream);
            }

            Console.WriteLine($"JPEG image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}