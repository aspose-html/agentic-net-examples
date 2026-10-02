// Log each successful SVG to BMP conversion with source and destination file paths for audit purposes.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string[] svgFiles = new[] { "sample1.svg", "sample2.svg" };
            foreach (string sourcePath in svgFiles)
            {
                // Ensure the SVG file exists
                if (!File.Exists(sourcePath))
                {
                    string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                    File.WriteAllText(sourcePath, svgContent);
                }

                string outputPath = Path.ChangeExtension(sourcePath, ".bmp");

                // Set up image save options for BMP format
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                    Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

                // Log successful conversion
                Console.WriteLine($"Converted SVG '{sourcePath}' to BMP '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}