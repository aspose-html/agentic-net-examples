// Generate PNG previews of HTML pages at 400 px width for thumbnail galleries.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output PNG paths
            string inputPath = "sample.html";
            string outputPath = "preview.png";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Sample</title></head><body><h1>Thumbnail Preview</h1><p>This is a sample HTML page.</p></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Create default image rendering options (PNG format by default)
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions();

            // Create an image device with the options and output file path
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);

            // Render the HTML document to the PNG image
            document.RenderTo(device);

            // Optionally dispose resources
            device.Dispose();
            document.Dispose();

            Console.WriteLine("PNG preview generated at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}