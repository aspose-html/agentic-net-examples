// Render an HTML document to a multi‑page TIFF image with custom DPI settings via ImageDevice.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML path
            string htmlPath = "sample.html";
            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath,
                    "<html><body>" +
                    "<h1>Page 1</h1>" +
                    "<div style='height:2000px; background:lightgray;'>Long content to generate multiple pages.</div>" +
                    "<h1>Page 2</h1>" +
                    "</body></html>");
            }

            // Define output TIFF path
            string outputPath = "output.tiff";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure rendering options for TIFF with custom DPI
            Aspose.Html.Rendering.Image.ImageRenderingOptions options =
                new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            // Set page size (e.g., A4) to allow multiple pages
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(595, 842)); // size in points

            // Create an ImageDevice with the options and output path
            Aspose.Html.Rendering.Image.ImageDevice device =
                new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);

            // Render the document to the device (produces multi‑page TIFF)
            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}