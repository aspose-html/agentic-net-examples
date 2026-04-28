// Set ImageRenderingOptions.AntiAliasing to false for faster JPG generation when visual quality is secondary.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.jpg";

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = false;

            Converter.ConvertHTML(htmlPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}