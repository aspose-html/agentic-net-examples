// Convert HTML to GIF animation by rendering each page to separate frames using ImageDevice settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output GIF paths
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            // Create a minimal multi-page HTML file
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        .page { width: 800px; height: 600px; border: 1px solid #000; margin-bottom: 20px; page-break-after: always; }
    </style>
</head>
<body>
    <div class=""page""><h1>Page 1</h1><p>This is the first frame.</p></div>
    <div class=""page""><h1>Page 2</h1><p>This is the second frame.</p></div>
    <div class=""page""><h1>Page 3</h1><p>This is the third frame.</p></div>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure image rendering options for GIF animation
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.UseAntialiasing = false;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

            // Create the image device with the specified options and output path
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);

            // Render the document to the GIF animation
            document.RenderTo(device);

            Console.WriteLine($"HTML has been converted to GIF animation at: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}