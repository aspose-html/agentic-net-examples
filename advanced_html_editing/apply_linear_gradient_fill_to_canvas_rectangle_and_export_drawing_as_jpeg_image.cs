// Apply a linear gradient fill to a canvas rectangle, and export the drawing as a JPEG image.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.IO;

namespace GradientCanvasExample
{
    class MemoryStreamProvider : ICreateStreamProvider
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
            // Do not dispose here; streams are needed later.
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
                var document = new HTMLDocument();
                var canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 500;
                canvas.Height = 200;
                document.Body.AppendChild(canvas);

                var context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
                var gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
                gradient.AddColorStop(0, "red");
                gradient.AddColorStop(0.5, "green");
                gradient.AddColorStop(1, "blue");
                context.FillStyle = gradient;
                context.FillRect(0, 0, canvas.Width, canvas.Height);

                var options = new ImageSaveOptions(ImageFormat.Jpeg);
                var provider = new MemoryStreamProvider();

                Converter.ConvertHTML(document, options, provider);

                var outputPath = "output.jpg";
                provider.Streams[0].Seek(0, SeekOrigin.Begin);
                using (FileStream file = File.Create(outputPath))
                {
                    provider.Streams[0].CopyTo(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}