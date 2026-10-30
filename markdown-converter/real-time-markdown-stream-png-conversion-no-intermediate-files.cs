// Perform real‑time conversion of a Markdown stream to PNG format without writing intermediate files.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;

sealed class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams = new List<MemoryStream>();

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
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
        Streams.Clear();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = "# Sample Title\nThis is **bold** text in markdown.";

            // Convert markdown to HTMLDocument
            var document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Configure image save options for PNG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Use custom stream provider to capture output in memory
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                if (provider.Streams.Count > 0)
                {
                    var stream = provider.Streams[0];
                    stream.Position = 0;

                    // Save the PNG to a file for demonstration purposes
                    string outputPath = "markdown_output.png";
                    using (var fileStream = File.Create(outputPath))
                    {
                        stream.CopyTo(fileStream);
                    }

                    Console.WriteLine($"Markdown has been converted to PNG and saved to '{outputPath}'.");
                }
                else
                {
                    Console.WriteLine("No image stream was generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}