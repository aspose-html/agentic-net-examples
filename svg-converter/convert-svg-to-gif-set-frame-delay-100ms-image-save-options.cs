// Convert an SVG to GIF and set the frame delay to 100 milliseconds using ImageSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.svg";
            string outputPath = "output.gif";

            System.IO.File.WriteAllText(
                inputPath,
                "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><circle cx='50' cy='50' r='40' fill='red' /></svg>"
            );

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Gif
            );

            // Note: Frame delay is not directly supported via ImageSaveOptions.
            Aspose.Html.Converters.Converter.ConvertSVG(inputPath, options, outputPath);

            Console.WriteLine("SVG converted to GIF successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}