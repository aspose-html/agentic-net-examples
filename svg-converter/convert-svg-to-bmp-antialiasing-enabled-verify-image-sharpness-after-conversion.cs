// Convert an SVG to BMP with antialiasing enabled and verify image sharpness after conversion.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG and output BMP paths
            string svgPath = "sample.svg";
            string outputPath = "output.bmp";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <circle cx='100' cy='100' r='80' fill='green' stroke='black' stroke-width='4'/>
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Configure image save options with antialiasing
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert SVG to BMP
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            // Verify the conversion result
            if (File.Exists(outputPath))
            {
                using (Image img = Image.FromFile(outputPath))
                {
                    if (img.Width > 0 && img.Height > 0)
                    {
                        Console.WriteLine("SVG successfully converted to BMP with antialiasing. Image dimensions: {0}x{1}", img.Width, img.Height);
                    }
                    else
                    {
                        Console.WriteLine("Conversion produced an image with invalid dimensions.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Conversion failed: output file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}