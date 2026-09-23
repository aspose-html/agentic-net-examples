// Configure HtmlLoadOptions to disable external resources, then render canvas and convert to JPEG safely.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "canvas_output.jpg");

            // Create a minimal HTML file with a canvas element
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Canvas Example</title></head>
<body>
<canvas id='myCanvas' width='200' height='200'></canvas>
</body>
</html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.GetElementsByTagName("canvas")[0];

            // Get 2D rendering context
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Perform drawing operations
            context.FillStyle = "#FF0000";
            context.FillRect(10, 10, 100, 100);

            // Configure image save options for JPEG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Create image device and render the document
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}