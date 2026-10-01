// Configure ImageSaveOptions to set color depth to 8‑bit for PNG output when reducing file size is required.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            // Define output PNG path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");
            // Configure image save options for PNG
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;
            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPath);
            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}