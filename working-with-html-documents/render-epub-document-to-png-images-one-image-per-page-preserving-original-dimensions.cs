// Render an EPUB document to PNG images, one image per page, preserving original dimensions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (replace with a valid path)
            string inputPath = "sample.epub";

            // Open EPUB file stream
            System.IO.Stream inputStream = System.IO.File.OpenRead(inputPath);

            // Configure image save options (PNG by default)
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.UseAntialiasing = true;
            options.BackgroundColor = System.Drawing.Color.White;

            // Create a custom stream provider to capture each page as a separate image
            MemoryStreamProvider provider = new MemoryStreamProvider();

            // Convert EPUB to images using the provider
            Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

            // Save each generated image stream to a PNG file
            int pageIndex = 0;
            foreach (var ms in provider.Streams)
            {
                ms.Position = 0;
                string outputFile = $"page_{pageIndex}.png";
                using (System.IO.FileStream fileStream = new System.IO.FileStream(outputFile, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    ms.CopyTo(fileStream);
                }
                pageIndex++;
            }

            System.Console.WriteLine("EPUB conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom provider that stores each page's image in a MemoryStream
class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
{
    private System.Collections.Generic.List<System.IO.MemoryStream> _streams = new System.Collections.Generic.List<System.IO.MemoryStream>();

    public System.Collections.Generic.IReadOnlyList<System.IO.MemoryStream> Streams => _streams;

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new System.IO.MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new System.IO.MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // No action needed for in-memory streams
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