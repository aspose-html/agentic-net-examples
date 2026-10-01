// Convert an SVG to BMP while specifying a DPI of 300 in ImageSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // SVG content to be converted
            string code = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>" +
                          "<rect width='200' height='200' fill='green'/>" +
                          "</svg>";

            // Output file path
            string savePath = "output.bmp";

            // Ensure the output directory exists
            string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(savePath));
            if (!string.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Configure image save options (BMP format)
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Convert SVG string to BMP image file
            Aspose.Html.Converters.Converter.ConvertSVG(code, ".", options, savePath);

            Console.WriteLine($"SVG has been successfully converted to BMP at: {Path.GetFullPath(savePath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}