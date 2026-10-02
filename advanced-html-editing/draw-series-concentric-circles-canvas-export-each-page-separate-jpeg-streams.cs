// Draw a series of concentric circles on a canvas, then export each page as separate JPEG streams.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Dom.Canvas;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
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

    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            // Create HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create canvas element
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
            for (int r = 20; r <= 200; r += 20)
            {
                context.BeginPath();
                context.Arc((double)canvas.Width / 2, (double)canvas.Height / 2, r, 0, 2 * System.Math.PI, false);
                context.StrokeStyle = "black";
                context.LineWidth = 2;
                context.Stroke();
            }

            // Prepare image save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Create custom stream provider
            MemoryStreamProvider provider = new MemoryStreamProvider();

            // Convert HTML to JPEG streams
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Ensure output directory exists
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);

            // Save each generated stream as a separate JPEG file
            for (int i = 0; i < provider.Streams.Count; i++)
            {
                var stream = provider.Streams[i];
                stream.Position = 0;
                string outputPath = System.IO.Path.Combine(outputDir, $"page_{i + 1}.jpg");
                using (System.IO.FileStream file = System.IO.File.Create(outputPath))
                {
                    stream.CopyTo(file);
                }
            }

            // Cleanup
            provider.Dispose();
            document.Dispose();

            Console.WriteLine("Concentric circles rendered and saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}