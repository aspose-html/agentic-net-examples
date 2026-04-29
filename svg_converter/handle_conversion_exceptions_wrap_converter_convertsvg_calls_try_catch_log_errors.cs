// Handle conversion exceptions by wrapping Converter.ConvertSVG calls in try‑catch blocks and logging errors.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "input.svg";
            string outputPath = "output.jpg";
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);
            Console.WriteLine("SVG conversion succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during SVG conversion: {ex.Message}");
        }
    }
}