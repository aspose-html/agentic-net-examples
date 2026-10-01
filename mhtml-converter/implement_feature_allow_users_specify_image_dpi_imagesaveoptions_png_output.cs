// Implement a feature that allows users to specify image DPI in ImageSaveOptions for PNG output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            Aspose.Html.Rendering.Image.ImageRenderingOptions renderOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
            {
                HorizontalResolution = 300,
                VerticalResolution = 300
            };

            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(renderOptions, "output.png");

            document.RenderTo(device);
            Console.WriteLine("PNG image saved with 300 DPI resolution.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}