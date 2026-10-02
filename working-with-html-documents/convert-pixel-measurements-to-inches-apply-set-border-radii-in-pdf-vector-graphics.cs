// Convert pixel measurements to inches and apply them to set border radii in PDF vector graphics.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel measurements
            double widthPixels = 200;
            double heightPixels = 100;
            const double ppi = 96.0;

            // Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Convert to points
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            // Output conversion results
            Console.WriteLine($"Width: {widthPixels} px => {widthInches:F4} in => {widthPoints:F2} pt");
            Console.WriteLine($"Height: {heightPixels} px => {heightInches:F4} in => {heightPoints:F2} pt");

            // Border radius in pixels and points
            double borderPixels = 5.0;
            double borderPoints = borderPixels * 72.0 / ppi;

            // Create a simple HTML document
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create a canvas element
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 300;
            canvas.Height = 200;

            // Apply border and border radius using points
            canvas.Style.Border = $"{borderPoints:F2}pt solid red";
            canvas.Style.SetProperty("border-radius", $"{borderPoints:F2}pt");

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Draw a rectangle on the canvas
            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "lightblue";
            context.FillRect(20, 20, 260, 160);

            // Render the document to PDF
            string outputPath = "output.pdf";
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