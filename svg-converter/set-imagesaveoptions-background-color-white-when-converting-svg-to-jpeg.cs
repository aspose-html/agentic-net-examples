// Set ImageSaveOptions background color to white when converting SVG to JPEG.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input SVG content
            string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
                                      <rect width='200' height='200' fill='red' />
                                   </svg>";

            // Paths for temporary SVG file and output JPEG
            string svgPath = "sample.svg";
            string outputPath = "output.jpg";

            // Write SVG content to file
            File.WriteAllText(svgPath, svgContent);

            // Configure image save options with white background
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.BackgroundColor = Color.White;

            // Convert SVG to JPEG
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("SVG successfully converted to JPEG with white background.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}