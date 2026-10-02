// Convert a single SVG file to BMP using the one‑line Converter.ConvertSVG method.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.svg";
            string outputPath = "output.bmp";
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);
            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}