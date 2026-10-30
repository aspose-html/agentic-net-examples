// Use Unit.GetValue to obtain point values from pixel counts for precise border thickness.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define border thickness in pixels
            double borderPixels = 5.0;

            // Convert pixels to points using Unit.GetValue
            var length = Aspose.Html.Drawing.Unit.FromPixels(borderPixels);
            double borderPoints = length.GetValue(Aspose.Html.Drawing.UnitType.Pt);
            Console.WriteLine($"Border thickness: {borderPixels} pixels => {borderPoints:F2} points");

            // Create an HTML document with a canvas
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create canvas element
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 200;
            canvas.Height = 100;
            canvas.Style.Border = $"{borderPoints:F2}pt solid red";

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Render the document to PDF
            string outputPath = "canvas_output.pdf";
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}