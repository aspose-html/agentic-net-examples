// Use a custom stream provider to write PNG output directly to a file.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;

sealed class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";

            // Create HTML document from content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure image save options for PNG format
            var options = new Aspose.Html.Saving.ImageSaveOptions();
            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;

            // Use custom stream provider to capture output streams
            var provider = new MemoryStreamProvider();

            // Convert HTML to PNG images using the provider
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Save each generated PNG stream to a file
            int index = 0;
            foreach (var ms in provider.Streams)
            {
                ms.Position = 0;
                string outputPath = $"output_{index}.png";
                using (FileStream fileStream = File.Create(outputPath))
                {
                    ms.CopyTo(fileStream);
                }
                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}