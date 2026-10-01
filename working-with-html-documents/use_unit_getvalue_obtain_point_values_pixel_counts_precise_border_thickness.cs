// Use Unit.GetValue to obtain point values from pixel counts for precise border thickness.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel to points conversion
            double pixels = 300.0;
            double points = pixels * 72.0 / 96.0;
            Console.WriteLine($"Pixel count: {{ {pixels} }} => {{ {points:F2} }} points");

            // Pixel to inches conversion
            double pixelCount = 480.0;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {{ {pixelCount} }} => Inches: {{ {inches:F4} }}");

            // Pixel to millimeters conversion
            double pixelsForMm = 200.0;
            const double ppi = 96.0;
            double millimeters = (pixelsForMm / ppi) * 25.4;
            Console.WriteLine($"Pixel: {{ {pixelsForMm} }} = {{ {millimeters:F2} }} mm");

            // Canvas border conversion and drawing
            double borderPixels = 5.0;
            double borderPoints = borderPixels * 72.0 / 96.0;

            // Create HTML document
            var document = new Aspose.Html.HTMLDocument();

            // Create canvas element
            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 400;
            canvas.Height = 200;
            canvas.Style.Border = $"{borderPoints:F2}pt solid red";

            // Append canvas to body
            document.Body.AppendChild(canvas);

            // Get 2D rendering context and draw a rectangle
            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "rgba(0, 120, 215, 0.6)";
            context.FillRect(50, 30, 300, 140);

            // Render document to PDF
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }
            Console.WriteLine($"PDF rendered to: {outputPath}");

            // Additional size conversions
            double widthPixels = 800.0;
            double heightPixels = 600.0;

            // Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // Convert to millimeters
            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            // Convert to points
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            // Convert to picas
            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            // Output results
            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F4} in = {widthCentimeters:F2} cm = {widthMillimeters:F1} mm = {widthPoints:F1} pt = {widthPicas:F2} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F4} in = {heightCentimeters:F2} cm = {heightMillimeters:F1} mm = {heightPoints:F1} pt = {heightPicas:F2} pc");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}