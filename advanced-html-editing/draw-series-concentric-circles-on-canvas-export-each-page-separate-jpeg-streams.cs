// Draw a series of concentric circles on a canvas, then export each page as separate JPEG streams.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Canvas;

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
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = (ulong)400;
            canvas.Height = (ulong)400;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Fill background
            context.FillStyle = "white";
            context.FillRect(0, 0, 400, 400);

            // Draw concentric circles
            double centerX = (double)canvas.Width / 2;
            double centerY = (double)canvas.Height / 2;
            for (int r = 20; r <= 200; r += 20)
            {
                context.BeginPath();
                context.Arc(centerX, centerY, r, 0, 2 * System.Math.PI, false);
                context.StrokeStyle = "black";
                context.LineWidth = 2;
                context.Stroke();
            }

            // Prepare image save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Use custom stream provider
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Create output directory
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
                Directory.CreateDirectory(outputDir);

                // Save each generated stream as a separate JPEG file
                int pageIndex = 1;
                foreach (var stream in provider.Streams)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    string filePath = Path.Combine(outputDir, $"page_{pageIndex}.jpg");
                    using (FileStream file = File.Create(filePath))
                    {
                        stream.CopyTo(file);
                    }
                    pageIndex++;
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