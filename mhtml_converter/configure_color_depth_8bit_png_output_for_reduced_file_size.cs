// Configure ImageSaveOptions to set color depth to 8‑bit for PNG output when reducing file size is required.

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
            // Sample HTML content to be converted
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "file:///";

            // Create ImageSaveOptions specifying PNG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);

            // Aspose.HTML does not expose a direct property for PNG color depth.
            // If such a property existed, it would be set here to 8-bit to reduce file size.
            // Example (hypothetical): options.ColorDepth = 8;

            // Perform the conversion to PNG
            string outputPath = "output.png";
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}