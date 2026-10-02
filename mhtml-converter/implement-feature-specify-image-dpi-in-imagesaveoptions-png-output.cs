// Implement a feature that allows users to specify image DPI in ImageSaveOptions for PNG output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var renderOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions()
            {
                HorizontalResolution = 300,
                VerticalResolution = 300,
                Format = Aspose.Html.Rendering.Image.ImageFormat.Png
            };

            var device = new Aspose.Html.Rendering.Image.ImageDevice(renderOptions, "output.png");
            document.RenderTo(device);

            Console.WriteLine("PNG image saved with 300 DPI.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}