// Perform SVG to BMP conversion with a specified pixel format by adjusting the conversion parameters.

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
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            // Set image save options for BMP format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Define output BMP file path
            string outputPath = "output.bmp";

            // Convert SVG to BMP
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine($"SVG has been successfully converted to BMP: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}