// Use Unit.FromPixels to calculate inch dimensions for a responsive layout and store them in a configuration file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // ✔ Use predefined pixel values
            double widthPixels = 800;
            double heightPixels = 600;

            const double ppi = 96.0;

            // ✔ Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // ✔ Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // ✔ Convert to millimeters
            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            // ✔ Convert to points
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            // ✔ Convert to picas
            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            // ✔ Output results
            System.Console.WriteLine($"Width: {widthPixels} px = {widthInches:F2} in = {widthCentimeters:F2} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            System.Console.WriteLine($"Height: {heightPixels} px = {heightInches:F2} in = {heightCentimeters:F2} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");

            double pixels = 300;
            double customDpi = 150.0;
            double inches = pixels / customDpi;
            System.Console.WriteLine($"Custom conversion: {pixels} px at {customDpi} DPI = {inches:F4} inches");

            // Prepare a simple HTML file
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body><h1>Hello Aspose.HTML</h1></body>
</html>";
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, htmlContent);

            // Load HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Set rendering options
                Aspose.Html.Rendering.Image.ImageRenderingOptions options =
                    new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Png)
                    {
                        HorizontalResolution = (int)customDpi,
                        VerticalResolution = (int)customDpi
                    };

                string outputPath = "output.png";

                // Render to image
                using (Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }
            }

            System.Console.WriteLine("Rendering completed successfully.");
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}