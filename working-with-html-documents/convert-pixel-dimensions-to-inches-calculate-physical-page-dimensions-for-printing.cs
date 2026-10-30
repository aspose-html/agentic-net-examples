// Convert pixel dimensions to inches and use them to calculate physical page dimensions for printing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel dimensions
            double widthPixels = 800;
            double heightPixels = 600;
            const double ppi = 96.0;

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
            System.Console.WriteLine($"Width: {widthPixels} px = {widthInches:F2} in = {widthCentimeters:F2} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            System.Console.WriteLine($"Height: {heightPixels} px = {heightInches:F2} in = {heightCentimeters:F2} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");

            // Alternative direct millimeter calculation
            double widthMillimetersAlt = widthPixels / 96.0 * 25.4;
            double heightMillimetersAlt = heightPixels / 96.0 * 25.4;

            // Prepare sample HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Test Page</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Set up image save options with page size based on calculated millimeters
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimetersAlt),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimetersAlt)
                )
            );

            // Convert HTML to JPEG image
            string outputImagePath = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, outputImagePath);

            System.Console.WriteLine("Conversion completed. Image saved to: " + outputImagePath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}