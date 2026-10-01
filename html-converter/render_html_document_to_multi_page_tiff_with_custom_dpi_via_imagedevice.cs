// Render an HTML document to a multi‑page TIFF image with custom DPI settings via ImageDevice.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define sample HTML with a page break to produce multiple pages
            string htmlContent = "<html><body><h1>Page 1</h1><div style='page-break-after:always;'></div><h1>Page 2</h1></body></html>";
            string htmlPath = "sample.html";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure rendering options for TIFF with custom DPI
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));

            // Create an ImageDevice that writes to a multi‑page TIFF file
            string outputPath = "output.tiff";
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);

            // Render the document to the device
            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}