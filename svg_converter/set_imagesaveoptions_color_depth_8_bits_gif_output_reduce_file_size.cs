// Set ImageSaveOptions color depth to 8 bits for GIF output to reduce file size.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";

            // Path where the GIF image will be saved
            string outputPath = "output.gif";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure image save options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert the HTML document to a GIF image
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}