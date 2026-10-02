// Convert SVG to JPG using ImageDevice, specifying 72 DPI resolution for web‑optimized image size.

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
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to JPG at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}