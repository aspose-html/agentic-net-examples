// Draw a series of concentric circles on a canvas, then export each page as separate JPEG streams.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

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
            // Create HTML document and canvas
            var document = new Aspose.Html.HTMLDocument();
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = (ulong)400;
            canvas.Height = (ulong)400;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "white";
            context.FillRect(0, 0, 400, 400);

            // Draw concentric circles
            for (int r = 20; r <= 200; r += 20)
            {
                context.BeginPath();
                context.Arc(200, 200, r, 0, 2 * Math.PI, false);
                context.StrokeStyle = "black";
                context.LineWidth = 2;
                context.Stroke();
            }

            // Prepare image save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Use custom stream provider to capture each page as a separate JPEG stream
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Ensure output directory exists
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
                Directory.CreateDirectory(outputDir);

                // Save each generated stream to a separate JPEG file
                for (int i = 0; i < provider.Streams.Count; i++)
                {
                    var stream = provider.Streams[i];
                    stream.Position = 0;
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.jpg");
                    using (var file = File.Create(outputPath))
                    {
                        stream.CopyTo(file);
                    }
                }
            }

            // Clean up document
            document.Dispose();

            Console.WriteLine("Concentric circles rendered and saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}