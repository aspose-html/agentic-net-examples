// Use ICanvasRenderingContext2D to draw a bezier curve, then save the drawing as a high‑resolution JPEG.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create an empty HTML document
            var document = new Aspose.Html.HTMLDocument();

            // Create a canvas element
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = (ulong)800;
            canvas.Height = (ulong)600;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Fill background
            context.FillStyle = "white";
            context.FillRect(0, 0, 800, 600);

            // Draw a Bezier curve
            context.BeginPath();
            context.MoveTo(100, 500);
            context.BezierCurveTo(200, 100, 600, 100, 700, 500);
            context.StrokeStyle = "blue";
            context.LineWidth = 5;
            context.Stroke();

            // Set high‑resolution JPEG options
            var options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Render to JPEG file
            string outputPath = "bezier_highres.jpg";
            var device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            document.RenderTo(device);

            System.Console.WriteLine("High‑resolution JPEG saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}