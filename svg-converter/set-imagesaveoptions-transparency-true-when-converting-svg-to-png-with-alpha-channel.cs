// Set ImageSaveOptions transparency to true when converting SVG to PNG with alpha channel.

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
            string sourcePath = "sample.svg";
            string outputPath = "output.png";

            // Create a minimal SVG file
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red' /></svg>";
            File.WriteAllText(sourcePath, svgContent);

            // Configure image save options for PNG with transparent background
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
            options.BackgroundColor = Color.Transparent;

            // Convert SVG to PNG
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine("SVG successfully converted to PNG with transparency.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}