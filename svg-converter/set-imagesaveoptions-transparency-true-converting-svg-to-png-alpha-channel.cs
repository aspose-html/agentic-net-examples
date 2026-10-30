// Set ImageSaveOptions transparency to true when converting SVG to PNG with alpha channel.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red' /></svg>";
            string outputPath = "output.png";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.BackgroundColor = System.Drawing.Color.Transparent;

            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, options, outputPath);
            Console.WriteLine("SVG converted to PNG with transparency successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}