// Log each successful SVG to BMP conversion with source and destination file paths for audit purposes.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // SVG content to be converted
            string code = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            // Output file path for the first conversion
            string savePath = "output.bmp";

            // Options for image saving (BMP format)
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Convert SVG string to BMP file
            Aspose.Html.Converters.Converter.ConvertSVG(code, ".", options, savePath);
            Console.WriteLine($"SVG string converted to BMP: {Path.GetFullPath(savePath)}");

            // Create a temporary SVG file for the second conversion
            string sourcePath = "sample.svg";
            File.WriteAllText(sourcePath, code);
            // Output file path for the second conversion
            string outputPath = "output2.bmp";

            // Options for the second conversion
            Aspose.Html.Saving.ImageSaveOptions options2 = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            // Convert SVG file to BMP file
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options2, outputPath);
            Console.WriteLine($"SVG file converted to BMP: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}