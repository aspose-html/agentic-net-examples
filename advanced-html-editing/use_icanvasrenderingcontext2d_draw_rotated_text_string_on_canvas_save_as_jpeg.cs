// Use ICanvasRenderingContext2D to draw a rotated text string on a canvas and save as JPEG.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

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
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string outputPath = "rotated_text.jpg";

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

            // Convert HTML to JPEG using in-memory provider
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Retrieve the generated image stream
                Stream imageStream = provider.Streams[0];
                imageStream.Seek(0, SeekOrigin.Begin);

                // Save to file
                using (FileStream file = File.Create(outputPath))
                {
                    imageStream.CopyTo(file);
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