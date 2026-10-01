// Create a naming pattern that includes conversion timestamp when saving BMP files from SVG sources.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG file path
            string sourcePath = "sample.svg";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>" +
                                    "<rect width='200' height='200' fill='green'/>" +
                                    "</svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            // Set image save options to BMP format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Define output BMP file path
            string outputPath = "output.bmp";

            // Convert SVG to BMP
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine($"SVG file '{sourcePath}' successfully converted to BMP file '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}