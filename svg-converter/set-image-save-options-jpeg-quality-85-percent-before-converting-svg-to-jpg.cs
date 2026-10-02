// Set ImageSaveOptions JPEG quality to 85 percent before converting SVG to JPG.

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
            string svgPath = "sample.svg";
            string outputPath = "output.jpg";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to JPEG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}