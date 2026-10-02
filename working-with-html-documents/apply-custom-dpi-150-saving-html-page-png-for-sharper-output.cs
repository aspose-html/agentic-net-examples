// Apply a custom DPI of 150 when saving an HTML page as a PNG image for sharper output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
            {
                HorizontalResolution = 150,
                VerticalResolution = 150
            };

            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, "output.png");
            document.RenderTo(device);

            Console.WriteLine("HTML page saved as PNG with 150 DPI.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}