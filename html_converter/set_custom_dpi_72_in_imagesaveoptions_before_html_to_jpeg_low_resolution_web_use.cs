// Set custom DPI of 72 in ImageSaveOptions before converting HTML to JPEG for low‑resolution web use.

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

            // Path where the JPEG image will be saved
            string outputPath = "output.jpg";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create image save options for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Set custom DPI to 72 for both dimensions
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            // Convert the HTML document to a JPEG image using the specified options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}