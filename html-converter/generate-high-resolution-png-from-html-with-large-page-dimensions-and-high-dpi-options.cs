// Generate a high‑resolution PNG from HTML by specifying large page dimensions and high DPI in options.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input HTML and output PNG paths
            string htmlPath = "sample.html";
            string outputPath = "high_res_output.png";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure high‑resolution rendering options with large page size
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(2000, 3000)); // width x height in pixels
            options.HorizontalResolution = 300; // DPI
            options.VerticalResolution = 300;   // DPI

            // Create an image device for PNG output
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);

            // Render the document to the PNG image
            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}