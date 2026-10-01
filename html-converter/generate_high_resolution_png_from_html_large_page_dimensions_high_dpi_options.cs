// Generate a high‑resolution PNG from HTML by specifying large page dimensions and high DPI in options.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file
            File.WriteAllText(htmlPath, "<html><body><h1>High Resolution PNG</h1><p>This is a test.</p></body></html>");

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure high‑resolution rendering options with large page size
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(2000, 3000));
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Create an image device for PNG output
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);

            // Render the document to the PNG file
            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}