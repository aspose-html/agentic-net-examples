// Convert HTML strings directly to BMP images by passing the string and ImageSaveOptions to Converter.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to be converted
            string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";

            // Base URI for the HTML content (empty means current directory)
            string baseUri = "";

            // Configure image save options for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Output BMP file path
            string outputPath = "output.bmp";

            // Convert the HTML string to BMP image
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            // Handle any conversion errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}