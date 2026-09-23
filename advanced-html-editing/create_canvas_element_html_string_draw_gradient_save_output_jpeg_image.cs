// Create a canvas element in an HTML string, draw a gradient, and save output as a JPEG image.

using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string outputPath = "canvas_gradient.jpg";

                // Create an empty HTML document
                var document = new Aspose.Html.HTMLDocument();

                // Create a canvas element
                var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = (ulong)500;
                canvas.Height = (ulong)200;
                document.Body.AppendChild(canvas);

                // Get 2D rendering context
                var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Create linear gradient
                var gradient = context.CreateLinearGradient(0, 0, (double)canvas.Width, 0);
                gradient.AddColorStop(0, "red");
                gradient.AddColorStop(0.5, "green");
                gradient.AddColorStop(1, "blue");

                // Apply gradient and draw rectangle
                context.FillStyle = gradient;
                context.FillRect(0, 0, (double)canvas.Width, (double)canvas.Height);

                // Save the rendered document as JPEG
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                var device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
                document.RenderTo(device);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}