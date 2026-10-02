// Create a unit test that verifies ImageSaveOptions correctly applies JPEG quality level during conversion.

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
            // Prepare sample SVG content
            string svgPath = "sample.svg";
            string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" fill=\"red\"/></svg>";
            File.WriteAllText(svgPath, svgContent);

            // Output paths
            string highOutputPath = "high_quality.jpg";
            string lowOutputPath = "low_quality.jpg";

            // High resolution conversion
            ImageSaveOptions highOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            highOptions.HorizontalResolution = 300;
            highOptions.VerticalResolution = 300;
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);

            // Low resolution conversion
            ImageSaveOptions lowOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            lowOptions.HorizontalResolution = 72;
            lowOptions.VerticalResolution = 72;
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            // Compare file sizes
            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;

            if (highSize > lowSize)
            {
                Console.WriteLine("Higher resolution JPEG is larger, indicating higher quality.");
            }
            else
            {
                Console.WriteLine("Unexpected result: lower resolution JPEG is not smaller.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}