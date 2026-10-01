// Convert HTML to GIF animation by rendering each page to separate frames using ImageDevice settings.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output GIF paths
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            // Create a simple multi-page HTML content
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        .page { width: 800px; height: 600px; border: 1px solid #000; margin: 0 auto; }
        .page:nth-child(odd) { background-color: #f0f0f0; }
        .page:nth-child(even) { background-color: #d0d0d0; }
        .page { page-break-after: always; }
    </style>
</head>
<body>
    <div class='page'><h1>Page 1</h1><p>Content of the first page.</p></div>
    <div class='page'><h1>Page 2</h1><p>Content of the second page.</p></div>
    <div class='page'><h1>Page 3</h1><p>Content of the third page.</p></div>
</body>
</html>";
            // Write the HTML content to a file
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image rendering options for GIF format
            Aspose.Html.Rendering.Image.ImageRenderingOptions renderOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            renderOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

            // Create an image device that will render each page as a frame in the GIF
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(renderOptions, outputPath);

            // Render the document to the GIF animation
            document.RenderTo(device);

            Console.WriteLine("HTML has been successfully converted to GIF animation: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}