// Render an HTML document to a multi‑page TIFF image with custom DPI settings via ImageDevice.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string outputPath = "output.tiff";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(htmlPath))
            {
                string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <style>
        .page { page-break-after: always; }
    </style>
</head>
<body>
    <div class='page'><h1>Page 1</h1><p>First page content.</p></div>
    <div class='page'><h1>Page 2</h1><p>Second page content.</p></div>
    <div class='page'><h1>Page 3</h1><p>Third page content.</p></div>
</body>
</html>";
                System.IO.File.WriteAllText(htmlPath, htmlContent);
            }

            // Configure image rendering options for multi‑page TIFF with custom DPI
            var renderingOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            renderingOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            renderingOptions.HorizontalResolution = 300;
            renderingOptions.VerticalResolution = 300;

            // Create an ImageDevice that writes to the specified TIFF file
            var device = new Aspose.Html.Rendering.Image.ImageDevice(renderingOptions, outputPath);

            // Load the HTML document from the file
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Render the document to the ImageDevice (produces multi‑page TIFF)
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}