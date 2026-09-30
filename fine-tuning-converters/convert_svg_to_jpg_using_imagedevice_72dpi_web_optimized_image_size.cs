// Convert SVG to JPG using ImageDevice, specifying 72 DPI resolution for web‑optimized image size.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "sample.svg";
            string outputPath = "output.jpg";

            if (!System.IO.File.Exists(svgPath))
            {
                System.IO.File.WriteAllText(svgPath,
                    "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>");
            }

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("SVG converted to JPG successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}