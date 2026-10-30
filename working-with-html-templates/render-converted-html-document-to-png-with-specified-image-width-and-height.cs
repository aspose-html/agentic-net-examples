// Render the converted HTML document to PNG with a specified image width and height.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image rendering options with desired width and height
            var renderingOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            renderingOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));

            // Create an image device targeting the output file
            var device = new Aspose.Html.Rendering.Image.ImageDevice(renderingOptions, outputPath);

            // Render the document to PNG
            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}