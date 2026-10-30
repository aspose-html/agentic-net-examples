// Convert an HTML document containing a canvas element to JPEG using ImageSaveOptions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file with a canvas element
            string htmlContent = "<!DOCTYPE html><html><body><canvas id='myCanvas' width='200' height='200'></canvas></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get the canvas element and draw on it
            HTMLCollection canvases = document.GetElementsByTagName("canvas");
            if (canvases.Length > 0)
            {
                HTMLCanvasElement canvas = (HTMLCanvasElement)canvases[0];
                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
                context.FillStyle = "#FF0000";
                context.FillRect(10, 10, 100, 100);
            }

            // Configure image save options for JPEG
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTML to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed. JPEG saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}