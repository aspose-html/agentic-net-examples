// Use ICanvasRenderingContext2D to draw a rotated text string on a canvas and save as JPEG.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.IO;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();
    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // Intentionally left empty to keep streams available for later reading.
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
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
            HTMLDocument document = new HTMLDocument();
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 400;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context and draw rotated text
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "white";
            context.FillRect(0, 0, 400, 200);
            context.Save();
            context.Translate(200, 100);
            context.Rotate(Math.PI / 4);
            context.FillStyle = "black";
            context.Font = "20px Arial";
            context.FillText("Rotated Text", 0, 0);
            context.Restore();

            // Prepare image save options for JPEG
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Use custom memory stream provider to capture output
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                Converter.ConvertHTML(document, options, provider);

                // Ensure the first stream is rewound before saving to file
                if (provider.Streams.Count > 0)
                {
                    Stream outputStream = provider.Streams[0];
                    outputStream.Seek(0, SeekOrigin.Begin);
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "rotated_text.jpg");
                    using (FileStream file = File.Create(outputPath))
                    {
                        outputStream.CopyTo(file);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}