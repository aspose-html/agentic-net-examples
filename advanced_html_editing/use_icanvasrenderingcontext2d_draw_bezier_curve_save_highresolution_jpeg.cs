// Use ICanvasRenderingContext2D to draw a bezier curve, then save the drawing as a high‑resolution JPEG.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.IO;

namespace BezierCanvasExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Output JPEG file path
                string outputPath = "bezier_curve.jpg";

                // Create an empty HTML document
                HTMLDocument document = new HTMLDocument();

                // Create a canvas element and set its size
                HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 800;
                canvas.Height = 600;
                document.Body.AppendChild(canvas);

                // Get 2D rendering context
                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Fill background with white
                context.FillStyle = "white";
                context.FillRect(0, 0, 800, 600);

                // Draw a cubic Bezier curve
                context.BeginPath();
                context.MoveTo(100, 500);
                context.BezierCurveTo(200, 100, 600, 100, 700, 500);
                context.StrokeStyle = "blue";
                context.LineWidth = 5;
                context.Stroke();

                // Prepare image save options for JPEG
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Use a custom memory stream provider to capture the output
                MemoryStreamProvider provider = new MemoryStreamProvider();

                // Convert the HTML document (with canvas) to JPEG
                Converter.ConvertHTML(document, options, provider);

                // Write the generated JPEG stream to a file
                using (FileStream file = File.Create(outputPath))
                {
                    provider.Streams[0].Seek(0, SeekOrigin.Begin);
                    provider.Streams[0].CopyTo(file);
                }

                Console.WriteLine($"Bezier curve image saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Custom provider that captures output streams in memory
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
            // Do not dispose here; streams are needed later
        }

        public void Dispose()
        {
            foreach (var ms in _streams)
            {
                ms.Dispose();
            }
        }
    }
}