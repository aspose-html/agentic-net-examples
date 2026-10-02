// Use Unit.GetValue to obtain point values from pixel counts for precise border thickness.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content
            string html = "<!DOCTYPE html><html><head><meta charset='utf-8'></head><body></body></html>";

            // Load document from inline HTML
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            // Create canvas element
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");

            // Set canvas size
            canvas.Width = 200;
            canvas.Height = 200;

            // Convert border thickness from pixels to points
            double borderPixels = 5.0;
            double borderPoints = borderPixels * 72.0 / 96.0;
            canvas.Style.Border = $"{borderPoints:F2}pt solid red";

            // Get 2D rendering context and draw
            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "blue";
            context.FillRect(10, 10, 180, 180);

            // Append canvas to document body
            document.Body.AppendChild(canvas);

            // Render to PDF
            string outputPath = "output.pdf";
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF generated successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}