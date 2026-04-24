// Create a canvas element in an HTML string, draw a gradient, and save output as a JPEG image.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.IO;

namespace CanvasGradientToJpeg
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Output file path
                string outputPath = "gradient.jpg";

                // Create an empty HTML document
                HTMLDocument document = new HTMLDocument();

                // Create a canvas element and set its size
                HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 500;
                canvas.Height = 200;
                document.Body.AppendChild(canvas);

                // Get 2D rendering context
                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Create a linear gradient and add color stops
                ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
                gradient.AddColorStop(0, "red");
                gradient.AddColorStop(0.5, "green");
                gradient.AddColorStop(1, "blue");

                // Fill the canvas with the gradient
                context.FillStyle = gradient;
                context.FillRect(0, 0, canvas.Width, canvas.Height);

                // Prepare JPEG save options
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Use a custom memory stream provider to capture the output
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    // Convert the HTML document to JPEG using the provider
                    Converter.ConvertHTML(document, options, provider);

                    // Ensure the stream is positioned at the beginning
                    provider.Streams[0].Seek(0, SeekOrigin.Begin);

                    // Write the JPEG data to a file
                    using (FileStream file = File.Create(outputPath))
                    {
                        provider.Streams[0].CopyTo(file);
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

    // Custom provider that captures output streams in memory
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
            // Do not dispose the stream here; it will be disposed in Dispose()
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
}