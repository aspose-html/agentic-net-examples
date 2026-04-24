// Draw a series of concentric circles on a canvas, then export each page as separate JPEG streams.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Create HTML document
            HTMLDocument document = new HTMLDocument();

            // Create canvas element
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = (ulong)400;
            canvas.Height = (ulong)400;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Fill background
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

            // Set image save options for JPEG
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Use custom memory stream provider to capture output streams
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Convert HTML document to JPEG images (one per page)
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Export each generated page as a separate JPEG stream (and optionally save to files)
                for (int i = 0; i < provider.Streams.Count; i++)
                {
                    MemoryStream stream = provider.Streams[i];
                    stream.Seek(0, SeekOrigin.Begin);

                    // Example: save to file named page{i}.jpg
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"page{i + 1}.jpg");
                    using (FileStream file = File.Create(outputPath))
                    {
                        stream.CopyTo(file);
                    }

                    // At this point, 'stream' contains the JPEG data for page i+1
                }
            }

            // Dispose document
            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom memory stream provider implementing ICreateStreamProvider
public class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        // Do not dispose here; streams are needed after conversion
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