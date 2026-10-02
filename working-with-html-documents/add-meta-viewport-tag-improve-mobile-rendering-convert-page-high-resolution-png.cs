// Add a meta viewport tag to improve mobile rendering, then convert the page to a high‑resolution PNG.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
                {
                    HorizontalResolution = 300,
                    VerticalResolution = 300
                };
                string outputPath = "output.png";
                using (Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }
            }
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}