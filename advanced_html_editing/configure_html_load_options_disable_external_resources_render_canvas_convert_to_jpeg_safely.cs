// Configure HtmlLoadOptions to disable external resources, then render canvas and convert to JPEG safely.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input HTML and output JPEG
            string inputPath = "input.html";
            string outputPath = "output.jpg";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(inputPath);

            // Locate the first <canvas> element in the document
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.GetElementsByTagName("canvas")[0];

            // Obtain a 2D rendering context for drawing
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Example drawing: fill a red rectangle on the canvas
            context.FillStyle = "#FF0000";
            context.FillRect(10, 10, 100, 100);

            // Configure JPEG output options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Create an image device that writes the rendered result to a JPEG file
            ImageDevice device = new ImageDevice(options, outputPath);

            // Render the modified HTML document to the JPEG image
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}