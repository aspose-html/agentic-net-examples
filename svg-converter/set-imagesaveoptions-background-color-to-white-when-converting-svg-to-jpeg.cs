// Set ImageSaveOptions background color to white when converting SVG to JPEG.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "sample.svg";
            string outputPath = "output.jpg";

            // Create a simple SVG file
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            File.WriteAllText(svgPath, svgContent);

            // Configure image save options with white background
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.BackgroundColor = Color.White;

            // Convert SVG to JPEG
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to JPEG with a white background.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}