// Convert a large Markdown file to BMP format using streaming to avoid high memory consumption.

using System;
using System.IO;
using System.Collections.Generic;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.md";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "# Sample Title\r\n\r\nThis is a sample markdown content.");
            }

            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                    if (provider.Streams.Count > 0)
                    {
                        var resultStream = provider.Streams[0];
                        resultStream.Position = 0;
                        using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                        {
                            resultStream.CopyTo(fileStream);
                        }
                        Console.WriteLine($"BMP image saved to {outputPath}");
                    }
                    else
                    {
                        Console.WriteLine("No image streams were generated.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}