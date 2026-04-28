// Convert HTML to JPG while preserving original aspect ratio by not specifying explicit width or height.

using System;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.jpg";

            HTMLDocument document = new HTMLDocument(inputPath);
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
            options.PageSetup.PageLayoutOptions = PageLayoutOptions.FitToWidestContentWidth;
            ImageDevice device = new ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}