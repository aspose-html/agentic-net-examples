// Convert HTML to GIF animation by rendering each page to separate frames using ImageDevice settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string outputPath = "output.gif";

            // Create a sample HTML file with two pages
            string htmlContent = "<html><body><h1>Page 1</h1><div style='page-break-after:always;'></div><h1>Page 2</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure rendering options for GIF animation
            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

            // Create an image device that writes to the output GIF file
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath);

            // Render each page of the document to a separate frame in the GIF
            document.RenderTo(device);

            Console.WriteLine("HTML successfully converted to GIF animation: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}