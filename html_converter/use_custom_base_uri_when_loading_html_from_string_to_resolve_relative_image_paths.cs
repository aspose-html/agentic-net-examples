// Use a custom base URI when loading HTML from string to correctly resolve relative image paths.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace HtmlBaseUriExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // HTML content containing a relative image path
                string htmlContent = "<html><body><img src=\"images/picture.png\" /></body></html>";
                // Custom base URI to resolve the relative image path
                string baseUri = "https://example.com/assets/";
                // Configure image save options for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                // Output file path for the generated image
                string outputPath = "output.jpg";

                // Convert the HTML string to a JPEG image using the custom base URI
                Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

                Console.WriteLine("HTML conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}