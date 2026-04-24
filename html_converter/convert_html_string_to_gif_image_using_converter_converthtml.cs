// Convert an HTML string directly to a GIF image by passing the string and output path to Converter.ConvertHTML.

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
            // HTML content to be converted
            string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
            // Base URI for the HTML content (can be any valid URI)
            string baseUri = "file:///";
            // Path where the GIF image will be saved
            string outputPath = "output.gif";

            // Configure image saving options to use GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert the HTML string directly to a GIF image
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}