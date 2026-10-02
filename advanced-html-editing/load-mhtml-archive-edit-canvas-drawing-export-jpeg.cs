// Load an MHTML email archive, edit its canvas drawing, and export the modified content to JPEG.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.mhtml";
            string outputPath = "output.jpg";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = @"From: example@example.com
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""

<html><body><canvas id=""c"" width=""200"" height=""200""></canvas></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Load the MHTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get the first canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.GetElementsByTagName("canvas")[0];

            // Obtain 2D rendering context
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Perform drawing operations
            context.FillStyle = "rgba(255,0,0,0.5)";
            context.FillRect(0, 0, 200, 200);

            // Prepare JPEG save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Render the modified document to JPEG
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            document.RenderTo(device);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}