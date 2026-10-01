// Use ICanvasRenderingContext2D to draw a bezier curve, then save the drawing as a high‑resolution JPEG.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create an empty HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Create a canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = (ulong)800;
            canvas.Height = (ulong)600;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Fill background with white
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
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Save the result to a file
            string outputPath = "bezier.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}