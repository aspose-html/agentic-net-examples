// Convert HTML strings directly to JPEG images by invoking Converter.ConvertHTML with appropriate parameters.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<h1>Convert HTML to JPG File Format!</h1>";
            string baseUri = ".";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("Conversion succeeded: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}