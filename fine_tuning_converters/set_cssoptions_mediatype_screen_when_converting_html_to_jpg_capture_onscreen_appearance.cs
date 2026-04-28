// Set CssOptions.MediaType to Screen when converting HTML to JPG to capture on‑screen appearance.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";
            // Desired output JPEG file path
            string outputPath = "output.jpg";

            // Create image save options for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Set CSS media type to Screen to capture on‑screen appearance
            options.Css.MediaType = MediaType.Screen;

            // Convert HTML to JPEG using the configured options
            Converter.ConvertHTML(htmlPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}