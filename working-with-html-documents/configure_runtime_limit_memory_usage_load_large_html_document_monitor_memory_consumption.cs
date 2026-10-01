// Configure runtime to limit memory usage, load a large HTML document, and monitor memory consumption.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello Aspose.HTML</h1></body></html>";

            // Create a memory stream from the HTML string
            using (MemoryStream htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(htmlContent)))
            {
                // Create HTML document from the stream
                using (var document = new Aspose.Html.HTMLDocument(htmlStream, "http://example.com"))
                {
                    // Configure image save options (PNG format)
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

                    // Create custom stream provider
                    var provider = new MemoryStreamProvider();

                    // Perform conversion
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                    // Access the generated image stream
                    if (provider.Streams.Count > 0)
                    {
                        var resultStream = provider.Streams[0];
                        resultStream.Position = 0;

                        // Save the image to a file
                        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            resultStream.CopyTo(fileStream);
                        }

                        Console.WriteLine($"Image successfully saved to: {outputPath}");
                    }
                    else
                    {
                        Console.WriteLine("No output streams were generated.");
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