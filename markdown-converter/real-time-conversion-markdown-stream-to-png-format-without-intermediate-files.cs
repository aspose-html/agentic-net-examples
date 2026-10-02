// Perform real‑time conversion of a Markdown stream to PNG format without writing intermediate files.

using System;
using System.IO;
using System.Collections.Generic;
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
            string markdown = "# Hello World\nThis is a **markdown** sample.";

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);

            // Configure image save options for PNG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            // Create in-memory stream provider
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Convert HTML to PNG using the provider
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Retrieve the generated PNG stream
                if (provider.Streams.Count > 0)
                {
                    MemoryStream pngStream = provider.Streams[0];
                    pngStream.Position = 0;

                    // Save the PNG to a file
                    string outputPath = "output.png";
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        pngStream.CopyTo(fileStream);
                    }

                    Console.WriteLine($"PNG image saved to: {outputPath}");
                }
                else
                {
                    Console.WriteLine("No PNG stream was generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}