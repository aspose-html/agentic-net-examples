// Create an HTML document, add a meta viewport for responsive design, and test on mobile rendering.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Inline HTML content with a placeholder body
            string htmlContent = "<!DOCTYPE html><html><head></head><body><h1>Hello Mobile</h1></body></html>";

            // Create HTML document from string (base URI is required)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create meta viewport element
            Aspose.Html.Dom.Element metaViewport = document.CreateElement("meta");
            metaViewport.SetAttribute("name", "viewport");
            metaViewport.SetAttribute("content", "width=device-width, initial-scale=1");

            // Append meta to the body (Head property is not available)
            document.Body.AppendChild(metaViewport);

            // Define output image path
            string outputPath = "mobile_render.jpg";

            // Configure image rendering options
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = false;
            options.VerticalResolution = Aspose.Html.Drawing.Resolution.FromDotsPerInch(96);
            options.HorizontalResolution = Aspose.Html.Drawing.Resolution.FromDotsPerInch(96);

            // Render the document to an image file
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);
            document.RenderTo(device);

            Console.WriteLine($"Rendered image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}