// Log each successful SVG to BMP conversion with source and destination file paths for audit purposes.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define source SVG and destination BMP paths
            string sourcePath = "sample.svg";
            string outputPath = "sample.bmp";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""100"" height=""100"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""100"" height=""100"" fill=""red"" />
</svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            // Set up image save options for BMP format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            // Log successful conversion
            Console.WriteLine($"Converted SVG: '{sourcePath}' -> BMP: '{outputPath}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during SVG to BMP conversion: " + ex.Message);
        }
    }
}