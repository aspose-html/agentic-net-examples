// Create an ImageSaveOptions for JPEG and set quality level before converting HTML to JPEG image.

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
            string htmlContent = "<html><body><h1>Hello Aspose HTML</h1></body></html>";
            // Base URI for resolving relative resources
            string baseUri = ".";

            // Output JPEG file path
            string outputPath = "output.jpg";

            // Create ImageSaveOptions for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // Note: Quality property is not available in this version of the API, so it is omitted.

            // Perform conversion
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("HTML successfully converted to JPEG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}