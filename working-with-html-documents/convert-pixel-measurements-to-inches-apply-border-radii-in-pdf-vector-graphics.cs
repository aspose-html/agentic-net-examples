// Convert pixel measurements to inches and apply them to set border radii in PDF vector graphics.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel measurements
            double widthPixels = 800;
            double heightPixels = 600;
            double borderPixels = 15;

            const double ppi = 96.0;

            // Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;
            double borderInches = borderPixels / ppi;

            // Convert to points (1 inch = 72 points)
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;
            double borderPoints = borderInches * 72.0;

            // Output conversion results
            Console.WriteLine($"Width: {widthPixels} px => {widthInches:F4} in => {widthPoints:F2} pt");
            Console.WriteLine($"Height: {heightPixels} px => {heightInches:F4} in => {heightPoints:F2} pt");
            Console.WriteLine($"Border radius: {borderPixels} px => {borderInches:F4} in => {borderPoints:F2} pt");

            // Create an HTML document with a canvas
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create canvas element
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            // Set canvas size (optional)
            canvas.Width = (ulong)widthPixels;
            canvas.Height = (ulong)heightPixels;

            // Apply border radius and border style using points
            canvas.Style.SetProperty("border-radius", $"{borderPoints:F2}pt", string.Empty);
            canvas.Style.Border = $"{borderPoints:F2}pt solid red";

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Draw a rectangle on the canvas
            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillRect(10, 10, 200, 100);

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