// Create an ImageDevice for JPG output with 600 DPI resolution and white background for high‑quality prints.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.jpg";

            // Create a minimal HTML file with white background
            System.IO.File.WriteAllText(htmlPath,
                "<!DOCTYPE html><html><head><style>body{background-color:white;}</style></head><body><h1>Sample</h1></body></html>");

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
            {
                HorizontalResolution = 600,
                VerticalResolution = 600
            };

            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);

            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}