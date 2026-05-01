// Render HTML to PNG with DPI set to 300 for high‑resolution image output.

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
            string htmlPath = "input.html";
            // Path for the output PNG image
            string outputPath = "output.png";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Set rendering options with 300 DPI for both dimensions
            ImageRenderingOptions options = new ImageRenderingOptions()
            {
                HorizontalResolution = 300,
                VerticalResolution = 300
            };

            // Create an image device for PNG output
            ImageDevice device = new ImageDevice(options, outputPath);

            // Render the HTML to the PNG image
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}