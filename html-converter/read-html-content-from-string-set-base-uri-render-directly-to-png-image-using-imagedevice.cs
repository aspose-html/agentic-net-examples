// Read HTML content from a string, set base URI, and render directly to a PNG image using ImageDevice.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";
            var document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            string outputPath = "output.png";

            var renderingOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            var imageDevice = new Aspose.Html.Rendering.Image.ImageDevice(renderingOptions, outputPath);

            document.RenderTo(imageDevice);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}