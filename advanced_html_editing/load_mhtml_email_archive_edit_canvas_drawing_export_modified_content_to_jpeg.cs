// Load an MHTML email archive, edit its canvas drawing, and export the modified content to JPEG.

using System;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Input MHTML file and output JPEG file paths
            string inputPath = "email.mhtml";
            string outputPath = "output.jpg";

            // Load the MHTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Locate the first canvas element
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.GetElementsByTagName("canvas")[0];

            // Obtain the 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Draw a red rectangle on the canvas
            context.FillStyle = "#FF0000";
            context.FillRect(10, 10, 200, 100);

            // Set JPEG image saving options
            ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Render the modified document to a JPEG image
            ImageDevice device = new ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}