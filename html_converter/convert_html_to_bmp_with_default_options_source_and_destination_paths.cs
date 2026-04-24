// Convert an HTML file to a BMP image with default options by specifying source and destination paths.

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
            string inputPath = "input.html";

            // Path where the BMP image will be saved
            string outputPath = "output.bmp";

            // Load the HTML document from the specified path
            HTMLDocument document = new HTMLDocument(inputPath);

            // Configure image saving options to use BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Convert the HTML document to a BMP image
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}