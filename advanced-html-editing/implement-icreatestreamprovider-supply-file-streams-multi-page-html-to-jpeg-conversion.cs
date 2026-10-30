// Implement ICreateStreamProvider to supply file streams for multi‑page HTML to JPEG conversion.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
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
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input HTML file
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            if (!File.Exists(inputPath))
            {
                string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        .page { page-break-after: always; height: 100vh; }
    </style>
</head>
<body>
    <div class='page'><h1>Page 1</h1></div>
    <div class='page'><h1>Page 2</h1></div>
</body>
</html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Load document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Configure image save options for JPEG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Create custom stream provider
            using (var provider = new MemoryStreamProvider())
            {
                // Convert HTML to JPEG pages using the provider
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Prepare output directory
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output_images");
                Directory.CreateDirectory(outputDir);

                // Save each generated page stream to a separate JPEG file
                for (int i = 0; i < provider.Streams.Count; i++)
                {
                    var memoryStream = provider.Streams[i];
                    memoryStream.Position = 0;
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.jpg");
                    using (var fileStream = File.Create(outputPath))
                    {
                        memoryStream.CopyTo(fileStream);
                    }
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}