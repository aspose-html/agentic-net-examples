// Load SVG content from a file and convert it to JPEG image using ImageDevice with quality parameter.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG file path
            string svgPath = "sample.svg";

            // Create a minimal SVG file if it does not exist
            if (!System.IO.File.Exists(svgPath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightblue"" />
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange"" />
</svg>";
                System.IO.File.WriteAllText(svgPath, svgContent);
            }

            // Define output JPEG file path
            string outputPath = "output.jpg";

            // Configure image save options for JPEG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.UseAntialiasing = true;

            // Convert SVG to JPEG
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to JPEG: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}