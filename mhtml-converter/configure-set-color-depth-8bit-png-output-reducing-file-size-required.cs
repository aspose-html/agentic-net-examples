// Configure ImageSaveOptions to set color depth to 8‑bit for PNG output when reducing file size is required.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string inputPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Define output PNG path
            string outputPath = "output.png";

            // Configure image save options for PNG with settings that help reduce file size
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 72; // lower DPI reduces size
            options.VerticalResolution = 72;
            options.BackgroundColor = System.Drawing.Color.White;

            // Note: Aspose.HTML does not expose a direct property to set PNG color depth (e.g., 8‑bit).
            // The available options are used here to achieve a smaller file size.

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, options, outputPath);

            Console.WriteLine("Conversion completed. PNG saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}