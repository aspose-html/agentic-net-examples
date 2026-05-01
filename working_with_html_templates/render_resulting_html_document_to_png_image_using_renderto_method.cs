// Render the resulting HTML document to a PNG image using the RenderTo method.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "input.html";
            string outputPath = "output.png";

            HTMLDocument document = new HTMLDocument(documentPath);
            ImageRenderingOptions options = new ImageRenderingOptions();
            ImageDevice device = new ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}