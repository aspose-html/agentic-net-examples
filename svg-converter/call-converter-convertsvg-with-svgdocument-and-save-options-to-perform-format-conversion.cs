// Call Converter.ConvertSVG with SVGDocument and save options to perform format conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare SVG content
            string svgCode = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><circle cx='100' cy='100' r='80' fill='green' /></svg>";

            // Define base URI (required by the overload)
            string baseUri = "about:blank";

            // Set image save options (convert to JPEG)
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Prepare output path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "converted.jpg");

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, baseUri, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to JPEG at:");
            Console.WriteLine(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during SVG conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}