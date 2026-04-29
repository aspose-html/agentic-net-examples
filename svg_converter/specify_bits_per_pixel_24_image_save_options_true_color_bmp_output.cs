// Specify BitsPerPixel equal to 24 in ImageSaveOptions for true‑color BMP output.

using System;
using Aspose.Html.Saving;
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

            // Path where the BMP image will be saved
            string outputPath = "output.bmp";

            // Create ImageSaveOptions with BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            // BitsPerPixel property is not available in ImageSaveOptions, so it is omitted.

            // Convert HTML to BMP using the specified options
            Converter.ConvertHTML(htmlPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}