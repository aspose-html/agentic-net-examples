// Generate PNG previews of HTML pages at 400 px width for thumbnail galleries.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Thumbnail Preview</h1><p>This is a sample HTML page.</p></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set rendering options
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Define page size (400px width, 600px height) with no margins
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(400, 600),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0));
            options.PageSetup.AnyPage = page;

            // Render to PNG file
            string outputPath = "thumbnail.png";
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            document.RenderTo(device);

            Console.WriteLine("Thumbnail image generated at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}