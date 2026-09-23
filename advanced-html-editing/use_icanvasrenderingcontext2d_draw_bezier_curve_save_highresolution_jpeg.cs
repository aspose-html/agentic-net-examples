// Use ICanvasRenderingContext2D to draw a bezier curve, then save the drawing as a high‑resolution JPEG.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "bezier_curve.jpg";

            // Create an empty HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create a canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = (ulong)800;
            canvas.Height = (ulong)600;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Fill background
            context.FillStyle = "white";
            context.FillRect(0, 0, 800, 600);

            // Draw a Bezier curve
            context.BeginPath();
            context.MoveTo(50, 300);
            context.BezierCurveTo(150, 100, 350, 500, 450, 300);
            context.StrokeStyle = "blue";
            context.LineWidth = 5;
            context.Stroke();

            // Set high‑resolution image options
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Render to JPEG file
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            document.RenderTo(device);

            Console.WriteLine("Image saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}