// Apply a custom DPI of 150 when saving an HTML page as a PNG image for sharper output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set custom DPI (150) for rendering
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
            {
                HorizontalResolution = 150,
                VerticalResolution = 150
            };

            // Render to PNG with the specified DPI
            string outputPath = "output.png";
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            document.RenderTo(device);

            Console.WriteLine("HTML page has been saved as PNG with 150 DPI to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}