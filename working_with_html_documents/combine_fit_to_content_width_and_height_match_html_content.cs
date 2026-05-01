// Combine PageLayoutOptions.FitToContentWidth and FitToContentHeight to match both width and height to HTML content.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string documentPath = Path.Combine(baseDir, "input.html");
            string outputPath = Path.Combine(baseDir, "output.png");

            using (HTMLDocument document = new HTMLDocument(documentPath))
            {
                ImageRenderingOptions options = new ImageRenderingOptions();
                options.PageSetup.PageLayoutOptions = PageLayoutOptions.FitToContentWidth | PageLayoutOptions.FitToContentHeight;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                ImageDevice device = new ImageDevice(options, outputPath);
                document.RenderTo(device);
            }

            Console.WriteLine("Rendering completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}