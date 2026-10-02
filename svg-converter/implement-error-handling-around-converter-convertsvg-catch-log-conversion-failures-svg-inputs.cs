// Implement error handling around Converter.ConvertSVG to catch and log conversion failures for SVG inputs.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG file
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Define output image path
            string outputPath = "output.jpg";

            // Set image save options (JPEG format)
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Convert SVG to image with error handling
            try
            {
                Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);
                Console.WriteLine("SVG conversion succeeded. Output saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during SVG conversion: " + ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}