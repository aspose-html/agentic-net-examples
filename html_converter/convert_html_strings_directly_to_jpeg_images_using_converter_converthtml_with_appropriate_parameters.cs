// Convert HTML strings directly to JPEG images by invoking Converter.ConvertHTML with appropriate parameters.

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
            // Base URI for resolving relative resources (if any)
            string baseUri = "file:///";

            // Configure image saving options for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Output file path for the generated JPEG image
            string outputPath = "output.jpg";

            // Perform the conversion from HTML string to JPEG image
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine($"Conversion completed. Image saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}