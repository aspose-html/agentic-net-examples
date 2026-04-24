// Convert HTML to JPEG with 72 DPI resolution by configuring ImageDevice DPI property accordingly.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string inputPath = "input.html";
            // Desired output JPEG file path
            string outputPath = "output.jpg";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Configure rendering options: JPEG format with 72 DPI resolution
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            // Create an image device using the options and output path
            ImageDevice device = new ImageDevice(options, outputPath);

            // Render the HTML document to the image device (produces the JPEG file)
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}