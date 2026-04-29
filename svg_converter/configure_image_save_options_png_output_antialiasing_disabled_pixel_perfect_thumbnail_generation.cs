// Configure ImageSaveOptions for PNG output with antialiasing disabled for pixel‑perfect thumbnail PNG generation process.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string sourcePath = "input.html";
            // Path for the generated PNG thumbnail
            string outputPath = "thumbnail.png";

            // Create ImageSaveOptions for PNG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            // Disable antialiasing for pixel‑perfect output
            options.UseAntialiasing = false;

            // Convert HTML to PNG using the configured options
            Converter.ConvertHTML(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}