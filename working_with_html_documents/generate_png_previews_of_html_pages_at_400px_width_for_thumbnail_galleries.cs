// Generate PNG previews of HTML pages at 400 px width for thumbnail galleries.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "thumbnail.png";

            HTMLDocument document = new HTMLDocument(htmlPath);
            ImageRenderingOptions options = new ImageRenderingOptions();
            ImageDevice device = new ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}