// Use a custom stream provider to write PNG output directly to a file.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
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
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Create HTML document
            using (HTMLDocument document = new HTMLDocument(string.Empty, htmlContent))
            {
                // Configure PNG image save options
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

                // Create custom stream provider
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert HTML to PNG using the provider
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                    // Save each generated PNG stream to a file
                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        var stream = provider.Streams[i];
                        stream.Position = 0;
                        string outputPath = $"output_page_{i}.png";
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            stream.CopyTo(fileStream);
                        }
                        Console.WriteLine($"Saved PNG to: {outputPath}");
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