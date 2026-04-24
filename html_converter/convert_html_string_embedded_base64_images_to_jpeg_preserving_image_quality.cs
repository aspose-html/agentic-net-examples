// Convert HTML string containing embedded base64 images to JPEG while preserving image quality.

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
            // HTML string with an embedded base64 image
            string htmlContent = "<html><body><img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUA\" /></body></html>";

            // Base URI for resolving relative resources (not needed for base64 but required by API)
            string baseUri = ".";

            // Configure JPEG output format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Output file path
            string outputPath = "output.jpg";

            // Convert HTML to JPEG
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}