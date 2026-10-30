// Create a unit test that verifies ImageSaveOptions correctly applies JPEG quality level during conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG file
            string svgPath = "sample.svg";
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            File.WriteAllText(svgPath, svgContent);

            // Output paths
            string highOutputPath = "high_res.jpg";
            string lowOutputPath = "low_res.jpg";

            // High resolution conversion
            Aspose.Html.Saving.ImageSaveOptions highOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            highOptions.HorizontalResolution = 300;
            highOptions.VerticalResolution = 300;
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);

            // Low resolution conversion
            Aspose.Html.Saving.ImageSaveOptions lowOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            lowOptions.HorizontalResolution = 72;
            lowOptions.VerticalResolution = 72;
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            // Compare file sizes
            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;

            if (highSize > lowSize)
            {
                Console.WriteLine("Higher resolution JPEG is larger.");
            }
            else
            {
                Console.WriteLine("Lower resolution JPEG is larger or equal.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}