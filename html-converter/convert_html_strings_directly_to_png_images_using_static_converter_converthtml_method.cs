// Convert HTML strings directly to PNG images using the static Converter.ConvertHTML method.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, World!</h1></body></html>";
            string baseUrl = "";
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            string outputPath = "output.png";

            Aspose.Html.Converters.Converter.ConvertHTML(html, baseUrl, options, outputPath);

            System.Console.WriteLine("Image saved to " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}