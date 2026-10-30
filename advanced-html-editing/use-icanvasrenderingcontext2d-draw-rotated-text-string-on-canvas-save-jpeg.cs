// Use ICanvasRenderingContext2D to draw a rotated text string on a canvas and save as JPEG.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string outputPath = "rotated_text.jpg";

            // Create an empty HTML document.
            var document = new Aspose.Html.HTMLDocument();

            // Create a canvas element.
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 400;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context.
            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Fill background.
            context.FillStyle = "white";
            context.FillRect(0, 0, 400, 200);

            // Draw rotated text.
            context.Save();
            context.Translate(200, 100);
            context.Rotate(System.Math.PI / 4);
            context.FillStyle = "black";
            context.Font = "20px Arial";
            context.FillText("Rotated Text", 0, 0);
            context.Restore();

            // Prepare image save options.
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Use a custom stream provider to capture the output in memory.
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Retrieve the generated stream.
                var stream = ((MemoryStreamProvider)provider).Streams[0];
                stream.Seek(0, SeekOrigin.Begin);

                // Save to a file.
                using (var file = File.Create(outputPath))
                {
                    stream.CopyTo(file);
                }
            }

            Console.WriteLine($"Image saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}