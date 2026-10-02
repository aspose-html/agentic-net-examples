// Write unit tests to verify that SVG to PNG conversion produces files of expected dimensions.

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
            // Prepare sample SVG content with known dimensions
            string svgPath = "sample.svg";
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='100'><rect width='200' height='100' fill='red'/></svg>";
            File.WriteAllText(svgPath, svgContent);

            // Define output PNG path
            string pngPath = "output.png";

            // Set image save options for PNG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            // Convert SVG to PNG
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, pngPath);

            // Verify the dimensions of the generated PNG
            using (Image img = Image.FromFile(pngPath))
            {
                int expectedWidth = 200;
                int expectedHeight = 100;

                if (img.Width == expectedWidth && img.Height == expectedHeight)
                {
                    Console.WriteLine("Test passed: PNG dimensions match expected values.");
                }
                else
                {
                    Console.WriteLine($"Test failed: Expected {expectedWidth}x{expectedHeight}, got {img.Width}x{img.Height}.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}