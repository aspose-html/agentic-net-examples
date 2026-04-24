// Define GIF frame delay in ImageSaveOptions to produce animated GIF output from HTML conversion.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";
            // Desired output GIF file path
            string outputPath = "output.gif";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure image save options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            // Note: Frame delay configuration is not available in the current API version

            // Convert the HTML document to an animated GIF (if supported)
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}