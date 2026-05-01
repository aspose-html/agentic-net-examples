// Use Unit.GetValue to obtain point values from pixel counts for precise border thickness.

using System;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel count for the border
            double borderPixels = 5.0;

            // Convert pixels to points using Length.GetValue with UnitType.Pt
            Length borderLength = Length.FromPixels(borderPixels);
            double borderPoints = borderLength.GetValue(UnitType.Pt);

            Console.WriteLine($"Border thickness: {borderPixels} px = {borderPoints:F2} pt");

            // Create an HTML document
            using (HTMLDocument document = new HTMLDocument())
            {
                // Create a canvas element
                HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 200;
                canvas.Height = 200;

                // Apply the border using the calculated point value
                canvas.Style.Border = $"{borderPoints:F2}pt solid red";

                // Add the canvas to the document body
                document.Body.AppendChild(canvas);

                // Draw something on the canvas
                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
                context.FillStyle = "blue";
                context.FillRect(10, 10, 180, 180);

                // Render the document to PDF
                string outputPath = "output.pdf";
                using (PdfDevice device = new PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"PDF generated at: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}