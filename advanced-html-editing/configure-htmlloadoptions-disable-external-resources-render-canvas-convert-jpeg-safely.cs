// Configure HtmlLoadOptions to disable external resources, then render canvas and convert to JPEG safely.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using Aspose.Html.Dom.Canvas;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string inputPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file with a canvas element
            string htmlContent = "<!DOCTYPE html><html><body><canvas width=\"200\" height=\"200\"></canvas></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get the canvas element
            var canvasCollection = document.GetElementsByTagName("canvas");
            HTMLCanvasElement canvas = (HTMLCanvasElement)canvasCollection[0];

            // Get 2D rendering context and draw
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "#FF0000";
            context.FillRect(10, 10, 100, 100);

            // Configure image save options for JPEG
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Render the document (including canvas) to JPEG
            ImageDevice device = new ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}