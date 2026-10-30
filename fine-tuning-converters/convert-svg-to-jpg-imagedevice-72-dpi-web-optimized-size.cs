// Convert SVG to JPG using ImageDevice, specifying 72 DPI resolution for web‑optimized image size.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal SVG file
            string svgPath = "sample.svg";
            if (!System.IO.File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                System.IO.File.WriteAllText(svgPath, svgContent);
            }

            // Output JPEG path
            string outputPath = "output.jpg";

            // Configure image save options with 72 DPI
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;
            options.UseAntialiasing = true;

            // Convert SVG to JPEG
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to JPEG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}