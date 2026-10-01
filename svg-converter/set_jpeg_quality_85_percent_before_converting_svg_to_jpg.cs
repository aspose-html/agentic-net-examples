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

            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
    <rect width='200' height='200' fill='lightblue'/>
    <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Note: ImageSaveOptions does not expose a JPEG quality property; using default quality.

            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to JPEG at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}