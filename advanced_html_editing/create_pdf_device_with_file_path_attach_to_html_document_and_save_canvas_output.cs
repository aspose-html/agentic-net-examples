// Create a PDF device with a file path, attach it to an HTMLDocument, and save the canvas output.

using System;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define output PDF file path
            string outputPath = "output.pdf";

            // Create an empty HTML document
            HTMLDocument document = new HTMLDocument();

            // Create a canvas element and set its size
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 150;
            document.Body.AppendChild(canvas);

            // Obtain 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Create a linear gradient brush
            ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "magenta");
            gradient.AddColorStop(0.4, "blue");
            gradient.AddColorStop(0.9, "red");

            // Apply gradient to fill and stroke styles
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;

            // Draw text and a filled rectangle on the canvas
            context.FillText("Hello World", 10, 90, 500);
            context.FillRect(0, 95, 500, 100);

            // Create a PDF device targeting the output file
            using (PdfDevice device = new PdfDevice(outputPath))
            {
                // Render the HTML document (including the canvas) to PDF
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}