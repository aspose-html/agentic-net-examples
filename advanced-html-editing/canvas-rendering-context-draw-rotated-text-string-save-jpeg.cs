// Use ICanvasRenderingContext2D to draw a rotated text string on a canvas and save as JPEG.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define output file path
            string outputPath = "rotated_text.jpg";

            // Create an empty HTML document
            HTMLDocument document = new HTMLDocument("<!DOCTYPE html><html><head></head><body></body></html>", "about:blank");

            // Create canvas element
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 400;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Draw background
            context.FillStyle = "white";
            context.FillRect(0, 0, 400, 200);

            // Draw rotated text
            context.Save();
            context.Translate(200, 100);
            context.Rotate(System.Math.PI / 4);
            context.FillStyle = "black";
            context.Font = "20px Arial";
            context.FillText("Rotated Text", 0, 0);
            context.Restore();

            // Prepare image save options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Use custom memory stream provider
            MemoryStreamProvider provider = new MemoryStreamProvider();

            // Convert HTML to image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

            // Save the first generated stream to a file
            if (provider.Streams.Count > 0)
            {
                provider.Streams[0].Seek(0, SeekOrigin.Begin);
                using (FileStream file = File.Create(outputPath))
                {
                    provider.Streams[0].CopyTo(file);
                }
            }

            Console.WriteLine("Image saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom provider for in‑memory stream output
class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        // No action needed; streams are retained for later use
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