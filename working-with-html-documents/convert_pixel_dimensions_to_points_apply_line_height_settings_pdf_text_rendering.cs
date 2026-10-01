// Convert pixel dimensions to points and apply them to line‑height settings in PDF text rendering.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define border size in pixels and convert to points
            double borderPixels = 5;
            double borderPoints = borderPixels * 72.0 / 96.0;

            // Create a simple HTML document
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Create a canvas element
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 200;   // pixels
            canvas.Height = 100;  // pixels
            canvas.Style.Border = $"{borderPoints:F2}pt solid red";

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Get 2D rendering context and draw a rectangle
            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "rgba(0,128,0,0.5)"; // semi‑transparent green
            context.FillRect(10, 10, 180, 80);

            // Prepare PDF rendering options (fit to content)
            var renderOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            renderOptions.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth |
                                                       Aspose.Html.Rendering.PageLayoutOptions.FitToContentHeight;

            // Render the document to a PDF file
            string outputPath = "output.pdf";
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(renderOptions, outputPath))
            {
                document.RenderTo(device);
            }

            // Compute and display dimensions in points
            double widthPixels = canvas.Width;
            double heightPixels = canvas.Height;
            double widthPoints = widthPixels * 72.0 / 96.0;
            double heightPoints = heightPixels * 72.0 / 96.0;
            Console.WriteLine($"Width in points: {widthPoints:F2}");
            Console.WriteLine($"Height in points: {heightPoints:F2}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}