// Convert HTML strings directly to JPEG images by invoking Converter.ConvertHTML with appropriate parameters.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<h1>Convert HTML to JPG File Format!</h1>";
            string baseUri = ".";
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("HTML has been successfully converted to JPEG at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}